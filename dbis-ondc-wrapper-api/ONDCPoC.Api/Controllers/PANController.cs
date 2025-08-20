using Microsoft.AspNetCore.Mvc;
using ONDCPoC.Api.Models;
using ONDCPoC.Core;

namespace ONDCPoC.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PANController(IONDCService ondcService) : ControllerBase
{
    [HttpPost(Name = "GetPANDetails")]
    public async Task<Core.Models.PAN.PANTransformedResponse?> GetPANDetails([FromBody] PANRequest request)
    {
        return await ondcService.GetPANDetailsAsync(request.pan).ConfigureAwait(false);
    }
}