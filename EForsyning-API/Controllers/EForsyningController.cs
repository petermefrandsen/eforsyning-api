using Microsoft.AspNetCore.Mvc;

namespace EForsyning_API;

[Route("api/[controller]")]
[ApiController]
public class EForsyningController : ControllerBase
{
    private readonly IEForsyningService _eForsyningService;
    
    public EForsyningController(IEForsyningService eForsyningService)
    {
        _eForsyningService = eForsyningService;    
    }

    [Route("getVaerkSettings")]
    [HttpGet]
    public async Task<VaerkSettings> GetVaerkSettings(string forsyningid)
    {
        return await _eForsyningService.GetVaerkSettings(forsyningid);
    }

    [Route("getAccessToken")]
    [HttpGet]
    public async Task<string> GetVaerkSettings(string forsyningid, string customerId, string customerPassword)
    {
        var vaerkSettings = await _eForsyningService.GetVaerkSettings(forsyningid);

        if(vaerkSettings.AppServerUri == null)
        {
            throw new Exception("AppServerUri is null");
        }

        var securityToken = await _eForsyningService.GetAccessToken(vaerkSettings.AppServerUri, customerId, customerPassword);
        
        return securityToken;
    }

    [Route("login")]
    [HttpGet]
    public async Task<LoginResult> Login(string forsyningid, string customerId, string customerPassword)
    {
        var vaerkSettings = await _eForsyningService.GetVaerkSettings(forsyningid);

        if(vaerkSettings.AppServerUri == null)
        {
            throw new Exception("AppServerUri is null");
        }

        var accessToken = await _eForsyningService.GetAccessToken(vaerkSettings.AppServerUri, customerId, customerPassword);
        
        var loginResponse = await _eForsyningService.Login(vaerkSettings.AppServerUri, customerId, accessToken);

        return loginResponse;
    }

    [Route("getUserInfo")]
    [HttpGet]
    public async Task<UserInfo> GetUserInfo(string forsyningid, string customerId, string customerPassword)
    {
        var vaerkSettings = await _eForsyningService.GetVaerkSettings(forsyningid);

        if(vaerkSettings.AppServerUri == null)
        {
            throw new Exception("AppServerUri is null");
        }

        var accessToken = await _eForsyningService.GetAccessToken(vaerkSettings.AppServerUri, customerId, customerPassword);
        
        var loginResponse = await _eForsyningService.Login(vaerkSettings.AppServerUri, customerId, accessToken);

        if(loginResponse.Result == 0)
        {
            throw new Exception("Unable to login, loginResponse.Result is 0");
        }

        var userInfo = await _eForsyningService.GetUserInfo(vaerkSettings.AppServerUri, accessToken);

        return userInfo;
    }

    [Route("getInstallations")]
    [HttpGet]
    public async Task<UserInstallationsResponse> GetInstallations(string forsyningid, string customerId, string customerPassword)
    {
        var vaerkSettings = await _eForsyningService.GetVaerkSettings(forsyningid);

        if(vaerkSettings.AppServerUri == null)
        {
            throw new Exception("AppServerUri is null");
        }

        var accessToken = await _eForsyningService.GetAccessToken(vaerkSettings.AppServerUri, customerId, customerPassword);
        
        var loginResponse = await _eForsyningService.Login(vaerkSettings.AppServerUri, customerId, accessToken);

        if(loginResponse.Result == 0)
        {
            throw new Exception("Unable to login, loginResponse.Result is 0");
        }

        var userInfo = await _eForsyningService.GetUserInfo(vaerkSettings.AppServerUri, accessToken);


        var installations = await _eForsyningService.GetInstallations(vaerkSettings.AppServerUri, accessToken, userInfo.Id.ToString());

        return installations;
    }

    [Route("getConsumption")]
    [HttpGet]
    public async Task<List<List<ConsumptionResponse>>> GetAllConsumption(string forsyningid, string customerId, string customerPassword)
    {
        var vaerkSettings = await _eForsyningService.GetVaerkSettings(forsyningid);

        if(vaerkSettings.AppServerUri == null)
        {
            throw new Exception("AppServerUri is null");
        }

        var accessToken = await _eForsyningService.GetAccessToken(vaerkSettings.AppServerUri, customerId, customerPassword);
        
        var loginResponse = await _eForsyningService.Login(vaerkSettings.AppServerUri, customerId, accessToken);

        if(loginResponse.Result == 0)
        {
            throw new Exception("Unable to login, loginResponse.Result is 0");
        }

        var userInfo = await _eForsyningService.GetUserInfo(vaerkSettings.AppServerUri, accessToken);
        int startYear = int.Parse(userInfo.StartDate.Split("-")[2]);  // TODO: make this optional / configurable

        var installations = await _eForsyningService.GetInstallations(vaerkSettings.AppServerUri, accessToken, userInfo.Id.ToString());

        var consumptionList = new List<List<ConsumptionResponse>>();
        foreach(var installation in installations.Installations)
        {
            var consumption = await _eForsyningService.GetConsumption(vaerkSettings.AppServerUri, accessToken, userInfo, installation, startYear);
            consumptionList.Add(consumption);
        }

        return consumptionList; // TODO: create a return model that is not two lists deep unless we create a master object that contains all the data e.g. datetime, userinfo, installation info and consumption
    }
}
