using Farmacia.Application.UseCase.Commons.Bases;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Exception = Farmacia.Application.UseCase.Commons.Exceptions;

namespace Farmacia.API.Extensions.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }catch (Exception.ValidationException ex)
            {
                context.Response.ContentType = "application/json";

                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    Message = "Errores de validacion",
                    Errors = ex.Errors
                });
            }
        }
    }
}
