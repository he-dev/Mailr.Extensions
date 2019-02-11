using System.Collections.Generic;
using JetBrains.Annotations;
using Mailr.Extensions.Gunter.Models.v1.Alerts;
using Mailr.Extensions.Models;
using Mailr.Extensions.Utilities.Mvc;
using Mailr.Extensions.Utilities.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Reusable.OmniLog.Mvc.Filters;
using Reusable.Utilities.AspNetCore.ActionFilters;

namespace Mailr.Extensions.Gunter.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/gunter/[controller]")]
    [Extension]
    public class AlertsController : Controller
    {
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidateModel))]
        [ServiceFilter(typeof(SendEmail))]
        [LogResponseBody]
        public IActionResult TestResult([FromBody] Email<TestResultBody> email)
        {
            return this.SelectEmailView(EmailView.Original)(null, email.Body);
        }
    }
}
