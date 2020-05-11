using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SSar.BC.Common.Application.Exceptions;

namespace SSar.Presentation.API.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(ValidationException))
            {
                HandleValidationException(context);
            }
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            var details = new ValidationProblemDetails(exception.Errors)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }
    }
}

// CREDIT: This page inspired by and heavily influenced by 
// Jason Taylor's CleanArchitecture example
// https://github.com/jasontaylordev/CleanArchitecture
