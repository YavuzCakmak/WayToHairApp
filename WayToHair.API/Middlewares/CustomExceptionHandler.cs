using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using WayToHair.Core.DTOs;
using WayToHair.Service.Exceptions;

namespace WayToHair.API.Middlewares
{

    public static class CustomExceptionHandler 
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => HttpStatusCode.BadRequest,
                        NotFoundException => HttpStatusCode.NotFound,
                        _ => HttpStatusCode.InternalServerError
                    };
                    context.Response.StatusCode = (int)statusCode;
                    var response = CustomResponseDto<NoContentDto>.Fail((int)statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
