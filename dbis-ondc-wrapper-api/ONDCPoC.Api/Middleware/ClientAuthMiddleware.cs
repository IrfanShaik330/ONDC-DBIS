using ONDCPoC.Core;

namespace ONDCPoC.Api.Middleware;

public class ClientAuthMiddleware(RequestDelegate next, Config ondcConfig)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value;

        // Allow Swagger UI and documentation endpoints without header validation
        if (path != null &&
     (path.StartsWith("/swagger", StringComparison.OrdinalIgnoreCase) ||
      path.StartsWith("/GST", StringComparison.OrdinalIgnoreCase)))
        {
            await next(context);
            return;
        }


        var clientIdFromHeaders = context.Request.Headers["clientId"].FirstOrDefault();
        var clientSecretFromHeaders = context.Request.Headers["clientSecret"].FirstOrDefault();

        if (clientIdFromHeaders != ondcConfig.DnbClientId || clientSecretFromHeaders != ondcConfig.DnbClientSecret)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized client.");
            return;
        }

        await next(context);
    }
}