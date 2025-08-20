using Microsoft.AspNetCore.Mvc;
using ONDCPoC.Api.Models;
using ONDCPoC.Core;

namespace ONDCPoC.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MSMEController(IONDCService ondcService) : ControllerBase
{
    [HttpPost(Name = "GetMSMEDetails")]
    public async Task<Core.Models.MSME.MSMETransformedResponse?> GetMSMEDetails([FromBody] MSMERequest request)
    {
        return await ondcService.GetMSMEDetailsAsync(request.registrationnumber).ConfigureAwait(false);
    }
}