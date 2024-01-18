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

    [Route("test")]
    [HttpGet]
    public async Task<string> test(string forsyningid)
    {
        return "You got it! " + forsyningid;
    }

    [Route("getVaerkSettings")]
    [HttpGet]
    public async Task<VaerkSettings> GetVaerkSettings(string forsyningid)
    {
        return await _eForsyningService.GetVaerkSettings(forsyningid);
    }
}
