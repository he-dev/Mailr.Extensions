using System.Collections.Generic;
using JetBrains.Annotations;
using v1 = Mailr.Extensions.Gunter.Models.v1.Alerts;
using v2 = Mailr.Extensions.Gunter.Models.v2.Alerts;
using Mailr.Extensions.Models;
using Mailr.Extensions.Utilities.Mvc;
using Mailr.Extensions.Utilities.Mvc.Filters;
using Mailr.Extensions.Utilities.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Reusable.OmniLog.Mvc.Filters;
using Reusable.Utilities.AspNetCore.ActionFilters;

namespace Mailr.Extensions.Gunter.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/gunter/[controller]")]
    [Extension]
    [ApiController]
    public class AlertsController : Controller
    {        
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidateModel))]
        [ServiceFilter(typeof(SendEmail))]
        [LogResponseBody]
        public IActionResult TestResult([FromBody] Email<v1.TestResultBody> email, [ModelBinder(typeof(EmailViewBinder))] EmailView view)
        {
            return this.SelectEmailView(EmailView.Original)("~/src/Views/v1/Alerts/TestResult.cshtml", email.Body);
            //return this.SelectEmailView(EmailView.Original)(null, email.Body);
        }
        
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidateModel))]
        [ServiceFilter(typeof(SendEmail))]
        [MapToApiVersion("2.0")]
        [LogResponseBody]
        public IActionResult TestResult([FromBody] Email<v2.TestResultBody> email, [ModelBinder(typeof(EmailViewBinder))] EmailView view)
        {
            return this.SelectEmailView(EmailView.Original)("~/src/Views/v2/Alerts/TestResult.cshtml", email.Body);
            //return this.SelectEmailView(EmailView.Original)(null, email.Body);
        }
    }
}
