namespace EForsyning_API;

public interface IEForsyningService
{
    public Task<VaerkSettings> GetVaerkSettings(string forsyningid);
}
