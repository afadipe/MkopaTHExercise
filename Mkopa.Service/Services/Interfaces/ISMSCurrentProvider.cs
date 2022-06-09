namespace Mkopa.Core.Services.Interfaces
{
    public interface ISMSCurrentProvider
    {
        ISMSProvider GetCurrentSMSProvider(string phoneNumber);
    }
}
