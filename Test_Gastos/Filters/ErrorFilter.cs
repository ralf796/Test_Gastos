using Test_Gastos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Test_Gastos.Filters
{
    public class ErrorFilter : IExceptionFilter
    {
        ILogger<ErrorFilter> _logger;
        public ErrorFilter(ILogger<ErrorFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception,context.Exception.Message);
            ErrorResponse error = new ErrorResponse(context.Exception);
            context.Result = new JsonResult(error)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                ContentType = "application/json",
            };
        }
    }
}
