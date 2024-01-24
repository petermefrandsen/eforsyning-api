namespace EForsyning_API;

public interface IEForsyningService
{
    public Task<VaerkSettings> GetVaerkSettings(string forsyningid);
    public Task<string> GetAccessToken(string vaerkApiServerUri, string eforsyningCustomerId, string eforsyningCutsomerPassword);
    public Task<LoginResult> Login(string vaerkApiServerUri, string eforsyningCustomerId, string accessToken);
    public Task<UserInfo> GetUserInfo(string vaerkApiServerUri, string accessToken);
    public Task<UserInstallationsResponse> GetInstallations(string vaerkApiServerUri, string accessToken, string userId);
    public Task<YearMark> GetYearMark(string vaerkApiServerUri, string accessToken);
    public Task<List<ConsumptionResponse>> GetConsumption(string vaerkApiServerUri, string accessToken, UserInfo userInfo, Installation installation, int year);
}
