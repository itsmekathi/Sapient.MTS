using Microsoft.AspNetCore.Http;
using Sapient.MTS.Common.Exceptions;
using Sapient.MTS.Common.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Sapient.MTS.WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var errorDetails = new ErrorDetails();

            if (exception is BaseApplicationException)
            {
                errorDetails.Message = exception.Message;

                switch (exception)
                {
                    case NotFoundException notFoundException:
                        errorDetails.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case InvalidRequestException invalidException:
                    case ValidationException validationException:
                        errorDetails.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    default:
                        break;
                }

                context.Response.StatusCode = errorDetails.StatusCode;
            }
            else
            {
                await logger.LogErrorAsync(exception);
                errorDetails.Message = "Internal Server Error, please contact your administrator.";
                errorDetails.StatusCode = (int)HttpStatusCode.InternalServerError;

                context.Response.StatusCode = errorDetails.StatusCode;
            }

            await context.Response.WriteAsync(errorDetails.ToString());
        }
    }
}
