using Microsoft.AspNetCore.Mvc;
using ONDCPoC.Api.Models;
using ONDCPoC.Core;

namespace ONDCPoC.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FSSAIController(IONDCService ondcService) : ControllerBase
{
    [HttpPost(Name = "GetFSSAIDetails")]
    public async Task<Core.Models.FSSAI.FSSAITransformedResponse?> GetFSSAIDetails([FromBody] FSSAIRequest request)
    {
        return await ondcService.GetFSSAIDetailsAsync(request.licenceNumber).ConfigureAwait(false);
    }
}