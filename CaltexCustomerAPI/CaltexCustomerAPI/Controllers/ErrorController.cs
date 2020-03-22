using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaltexCustomerAPI.Controllers
{
    [Route("error")]
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }
        protected IActionResult LogError()
        {
            //Get the exception
            var excep = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if(excep != null)
            {
                // Get the error path

                string path = excep.Path;

                // Extract the exception

                Exception ex = excep.Error;

                var error = new { ErrorMessage = ex.Message, ErrorPath = path };

                // The exception is logged to the output window currently, but it can be logged to a flat file using Nlog
                logger.LogError($"The path {error.ErrorPath} threw an exception + { error.ErrorMessage}");

                return BadRequest(error);
            }
            return BadRequest();
        }

    }
}
