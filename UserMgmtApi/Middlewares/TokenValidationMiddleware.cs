using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;

namespace UserManagementAPI.Middleware
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public TokenValidationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token) || token != _configuration["Jwt:Key"])
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            await _next(context);
        }
    }
}
