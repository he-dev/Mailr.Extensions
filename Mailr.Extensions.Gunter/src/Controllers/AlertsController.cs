﻿using Mailr.Extensions.Gunter.Models.Alerts;
//using v1 = Mailr.Extensions.Gunter.Models.v1.Alerts;
using Mailr.Extensions.Models;
using Mailr.Extensions.Utilities.Mvc;
using Mailr.Extensions.Utilities.Mvc.Filters;
using Mailr.Extensions.Utilities.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Reusable.OmniLog.Utilities.AspNetCore.Mvc.Filters;
using Reusable.Utilities.AspNetCore.ActionFilters;

namespace Mailr.Extensions.Gunter.Controllers
{
    [Area("Gunter")]
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/gunter/[controller]")]
    [ApiController]
    public class AlertsController : Controller
    {
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidateModel))]
        [ServiceFilter(typeof(SendEmail))]
        [MapToApiVersion("3.0")]
        [ServiceFilter(typeof(LogResponseBody))]
        public IActionResult TestResult([FromBody] Email<TestResultBody> email, [ModelBinder(typeof(EmailViewBinder))] EmailView view)
        {
            return this.SelectEmailView(view)("/src/Views/Alerts/TestResult.cshtml", new TestResult { Body = email.Body, Footer = new Footer() });
        }
        
        [HttpPost("TestResult")]
        [ServiceFilter(typeof(ValidateModel))]
        [ServiceFilter(typeof(SendEmail))]
        [MapToApiVersion("4.0")]
        [ServiceFilter(typeof(LogResponseBody))]
        public IActionResult TestResult4([FromBody] Email<TestResultBody> email, [ModelBinder(typeof(EmailViewBinder))] EmailView view)
        {
            return this.SelectEmailView(view)("/src/Views/Reports/TestResult.cshtml", new TestResult { Body = email.Body, Footer = new Footer() });
        }
    }
}