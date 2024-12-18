using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using FluentValidation;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
namespace E_commerce_.netcore.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            if (exception.GetType() == typeof(ValidationException))
            {
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    Errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage),
                    StatusCode = StatusCodes.Status400BadRequest
                }).ToString());
            }
            List<string> errors = new List<string>()
            {
                exception?.Message
            };
            if (exception.InnerException != null)
            {
                errors.Add(exception.InnerException.ToString());
            }
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                Errors = errors,
                StatusCode = statusCode
            }).ToString());

        }

        public static int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status400BadRequest,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };

        }
    }
}
