using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Core.Exceptions
{
    public class CustomExceptionFilter:IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Define a default response status and message
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "An unexpected error occurred.";

            // Customize the response for specific exception types
            if (context.Exception is NotFoundException)
            {
                statusCode = HttpStatusCode.NoContent;
                message = context.Exception.Message;
            }

            if (context.Exception is BaseNotFoundException)
            {
                statusCode = (HttpStatusCode)452;
                message = context.Exception.Message;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                message = "Unauthorized access.";
            }

            // Set the response
            context.Result = new JsonResult(new
            {
                StatusCode = (int)statusCode,
                Message = message
            })
            {
                StatusCode = (int)statusCode
            };

            // Mark the exception as handled
            context.ExceptionHandled = true;
        }
    }
}
