
using Flurl;
using Flurl.Http;

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
            .GetJsonAsync<VaerkSettings>();

        _logger.LogInformation("{Class}.{Method}: Retrieved VaerkSettings, {response}, succesfully", this.GetType().Name, nameof(GetVaerkSettings), response);

        return response;
    }
}
