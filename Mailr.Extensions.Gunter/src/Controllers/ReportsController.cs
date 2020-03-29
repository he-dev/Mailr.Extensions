using Mailr.Extensions.Gunter.Models.Reports;
using Mailr.Extensions.Models;
using Mailr.Extensions.Utilities.Mvc;
using Mailr.Extensions.Utilities.Mvc.Filters;
using Mailr.Extensions.Utilities.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Reusable.OmniLog.Utilities.AspNetCore.Mvc.Filters;
using Reusable.Utilities.AspNetCore.ActionFilters;

namespace Mailr.Extensions.Gunter.Controllers
{
    [Area("Gunter")]
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    [ApiVersion("4.0")]
    [Route("api/v{version:apiVersion}/gunter/[controller]")]
    [ApiController]
    public class ReportsController : Controller
    {
        [HttpPost("TestResult")]
        [ServiceFilter(typeof(ValidateModel))]
        [ServiceFilter(typeof(SendEmail))]
        [MapToApiVersion("4.0")]
        [ServiceFilter(typeof(LogResponseBody))]
        public IActionResult TestResult([FromBody] Email<TestResultBody> email, [ModelBinder(typeof(EmailViewBinder))] EmailView view)
        {
            return this.SelectEmailView(view)("/src/Views/Reports/TestResult.cshtml", new TestResult { Body = email.Body, Footer = new Footer() });
        }
    }
}