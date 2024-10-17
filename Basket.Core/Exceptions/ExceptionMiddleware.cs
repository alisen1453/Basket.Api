using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Exceptions
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
                await HandleException(context, ex);

            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            int statusCode = GetSatusCode(ex);
            context.Response.ContentType = MediaTypeNames.Application.Json;
          
            context.Response.StatusCode = statusCode;
            List<string> errors = new()
            {
            ex.Message,
            ex?.InnerException?.ToString()

            };
            return context.Response.WriteAsync(new ExceptionModel
            {
                Errors = errors,
                statuscode = statusCode


            }.ToString());
        }
        private static int GetSatusCode(Exception ex) =>
            ex switch
            {
                
                BadRequestException => StatusCodes.Status400BadRequest,
                //NotFoundException => StatusCodes.Status400BadRequest,
                ValidationException => StatusCodes.Status402PaymentRequired,
                _ => StatusCodes.Status500InternalServerError,


            };


    }
}
