
using System.Security.Cryptography;
using System.Text;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Identity;

namespace EForsyning_API;

public class EForsyningService : IEForsyningService
{
    private const string _baseUrl = "https://eforsyning.dk";
    private readonly ILogger<EForsyningService> _logger;

    public EForsyningService(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<EForsyningService>();
    }

    public async Task<VaerkSettings> GetVaerkSettings(string forsyningid)
    {
        _logger.LogInformation("{Class}.{Method}: Attempting to retrieve VaerkSettings for forsyningsId: {forsyningsId}", this.GetType().Name, nameof(GetVaerkSettings), forsyningid);

        var response = await _baseUrl
            .AppendPathSegment("umbraco/dff/dffapi/GetVaerkSettings")
            .SetQueryParam("forsyningid", forsyningid)
            .WithHeaders(CreateHeaders())
            .GetJsonAsync<VaerkSettings>();

        _logger.LogInformation("{Class}.{Method}: Retrieved VaerkSettings, {response}, succesfully", this.GetType().Name, nameof(GetVaerkSettings), response);

        return response;
    }
    
    public async Task<string> GetAccessToken(string vaerkApiServerUri, string eforsyningCustomerId, string eforsyningCutsomerPassword)
    {
        _logger.LogInformation("{Class}.{Method}: Attempting to retrieve SecurityToken for customerId: {eforsyningCustomerId}", this.GetType().Name, nameof(GetAccessToken), eforsyningCustomerId);

        var response = await vaerkApiServerUri
            .AppendPathSegment("system/getsecuritytoken/project/app/consumer/")
            .AppendPathSegment(eforsyningCustomerId)
            .WithHeaders(CreateHeaders())
            .GetJsonAsync<SecurityToken>();

        if(response.Token == null)
        {
            throw new Exception("SecurityToken is null");
        }

        var accessToken = "";
        string passHash = CreateMD5(eforsyningCutsomerPassword);
        accessToken = CreateMD5(passHash + response.Token);

        _logger.LogInformation("{Class}.{Method}: Retrieved SecurityToken, {response}, succesfully", this.GetType().Name, nameof(GetAccessToken), response);

        return accessToken;
    }

    public async Task<LoginResult> Login(string vaerkApiServerUri, string eforsyningCustomerId, string accessToken)
    {
        _logger.LogInformation("{Class}.{Method}: Attempting to Login for customerId: {eforsyningCustomerId}", this.GetType().Name, nameof(Login), eforsyningCustomerId);
        
        var response = await vaerkApiServerUri
            .AppendPathSegment($"system/login/project/app/consumer/{eforsyningCustomerId}/installation/1/id/{accessToken}")
            .WithHeaders(CreateHeaders())
            .GetJsonAsync<LoginResult>();

        _logger.LogInformation("{Class}.{Method}: Received a login response, {response}, succesfully", this.GetType().Name, nameof(Login), response);

        return response;
    }

    public async Task<UserInfo> GetUserInfo(string vaerkApiServerUri, string accessToken)
    {
        _logger.LogInformation("{Class}.{Method}: Attempting to retrieve UserInfo for accessToken: {accessToken}", this.GetType().Name, nameof(GetUserInfo), accessToken);

        var response = await vaerkApiServerUri
            .AppendPathSegment("api/getebrugerinfo")
            .SetQueryParam("id", accessToken)
            .WithHeaders(CreateHeaders())
            .GetJsonAsync<UserInfo>();

        _logger.LogInformation("{Class}.{Method}: Retrieved UserInfo, {response}, succesfully", this.GetType().Name, nameof(GetUserInfo), response);

        return response;
    }

    public async Task<UserInstallationsResponse> GetInstallations(string vaerkApiServerUri, string accessToken, string userId)
    {
        _logger.LogInformation("{Class}.{Method}: Attempting to retrieve Installations for accessToken: {accessToken}", this.GetType().Name, nameof(GetInstallations), accessToken);

        var response = await vaerkApiServerUri
            .AppendPathSegment("api/FindInstallationer")
            .SetQueryParam("id", accessToken)
            .WithHeaders(CreateHeaders())
            .PostJsonAsync(new {
                Soegetekst = "",
                Skip = "0",
                Take = "10000",
                EBrugerId = userId,
                Huskeliste = "null",
                MedtagTilknyttede = "true"
            })
            .ReceiveJson<UserInstallationsResponse>();

        _logger.LogInformation("{Class}.{Method}: Retrieved Installation, {response}, succesfully", this.GetType().Name, nameof(GetInstallations), response);

        return response;
    }

    public async Task<YearMark> GetYearMark(string vaerkApiServerUri, string accessToken)
    {
        _logger.LogInformation("{Class}.{Method}: Attempting to retrieve YearMark for accessToken: {accessToken}", this.GetType().Name, nameof(GetYearMark), accessToken);

        var response = await vaerkApiServerUri
            .AppendPathSegment("api/getaktuelaarsmaerke")
            .SetQueryParam("id", accessToken)
            .WithHeaders(CreateHeaders())
            .GetJsonAsync<YearMark>();

        _logger.LogInformation("{Class}.{Method}: Retrieved YearMark, {response}, succesfully", this.GetType().Name, nameof(GetYearMark), response);

        return response;
    }

    public async Task<List<ConsumptionResponse>> GetConsumption(string vaerkApiServerUri, string accessToken, UserInfo userInfo, Installation installation, int year)
    {
        var consumptionResponses = new List<ConsumptionResponse>();

        while(year <= DateTime.UtcNow.Year)
        {
            var request = new ConsumptionRequest
            {
                Year = year,
                AssetNumber = installation.AssetNumber,
                BuildingNumber = userInfo.BuildingNumber,
                InstallationNumber = installation.InstallationNumber
            };
            
            var response = await vaerkApiServerUri
                .AppendPathSegment("api/getforbrug")
                .SetQueryParam("id", accessToken)
                .WithHeaders(CreateHeaders())
                .PostJsonAsync(request)
                .ReceiveJson<ConsumptionResponse>();

            consumptionResponses.Add(response);

            year++;
        }

        return consumptionResponses;
    }

    private static Object CreateHeaders()
    {
        var sessionId = Guid.NewGuid().ToString()[..8];
        var correlationId = Guid.NewGuid().ToString()[..8];
        
        return new {
            Accept = "application/json",
            X_Session_ID = sessionId,
            X_Correlation_ID = correlationId,
            User_Agent = "Eforsyning integration, C# module"
        };
    }

    public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
}
