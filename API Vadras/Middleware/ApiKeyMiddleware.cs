using API_Vadras.Repository.ApiKeyRepo;

namespace API_Vadras.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IApiKey apiKeyRepo)
        {
            var path = context.Request.Path.Value?.ToLower() ?? "";

            // Pusti login bez ključa
            if (path.Contains("/api/radnici/login"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue("X-API-KEY", out var key) || string.IsNullOrWhiteSpace(key))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Missing API key");
                return;
            }

            var valid = await apiKeyRepo.GetValidAsync(key!);
            if (valid == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid or expired API key");
                return;
            }

            // (opciono) setuj radnika za kasnije
            context.Items["RadnikId"] = valid.RadnikId;

            await _next(context);
        }
    }
}
