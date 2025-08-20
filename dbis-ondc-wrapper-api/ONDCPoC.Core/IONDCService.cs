using ONDCPoC.Core.Models.GST;

namespace ONDCPoC.Core;

public interface IONDCService
{
    Task<Models.PAN.PANTransformedResponse?> GetPANDetailsAsync(string pan);
    Task<GstTransformedResponse?> GetGSTDetailsAsync(string gstin);
    Task<Models.FSSAI.FSSAITransformedResponse?> GetFSSAIDetailsAsync(string licenceNumber);
    Task<Models.MSME.MSMETransformedResponse?> GetMSMEDetailsAsync(string msme);
}
