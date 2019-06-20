using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using Mailr.Extensions.Gunter.Models.Alerts;
//using v1 = Mailr.Extensions.Gunter.Models.v1.Alerts;
using Mailr.Extensions.Models;
using Mailr.Extensions.Utilities.Mvc;
using Mailr.Extensions.Utilities.Mvc.Filters;
using Mailr.Extensions.Utilities.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Reusable.OmniLog.Mvc.Filters;
using Reusable.Utilities.AspNetCore.ActionFilters;

namespace Mailr.Extensions.Gunter.Controllers
{
    //[Area("test")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/gunter/[controller]")]
    [Extension]
    [ApiController]
    public class AlertsController : Controller
    {        
        //[HttpPost("[action]")]
        //[ServiceFilter(typeof(ValidateModel))]
        //[ServiceFilter(typeof(SendEmail))]
        //[LogResponseBody]
        //public IActionResult TestResult([FromBody] Email<v1.TestResultBody> email, [ModelBinder(typeof(EmailViewBinder))] EmailView view)
        //{
        //    return this.SelectEmailView(view)("~/src/Views/v1/Alerts/TestResult.cshtml", email.Body);
        //    //return this.SelectEmailView(EmailView.Original)(null, email.Body);
        //}
        
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidateModel))]
        [ServiceFilter(typeof(SendEmail))]
        [MapToApiVersion("2.0")]
        [LogResponseBody]
        public IActionResult TestResult([FromBody] Email<TestResultBody> email, [ModelBinder(typeof(EmailViewBinder))] EmailView view)
        {
            //using (var writer = new StringWriter())
            //{
            //    var viewEngine = HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
            //    var viewResult = viewEngine.FindView(ControllerContext, "TestResult", false);
            //    if (viewResult.Success)
            //    {
            //        //viewResult = View("~/src/Views/v2/Alerts/TestResult.cshtml", email.Body)

            //        var viewContext = new ViewContext(
            //            ControllerContext,
            //            viewResult.View,
            //            ViewData,
            //            TempData,
            //            writer,
            //            new HtmlHelperOptions()
            //        );

            //        viewResult.View.RenderAsync(viewContext).GetAwaiter().GetResult();

            //        var text = writer.GetStringBuilder().ToString();
            //    }
            //}

            return this.SelectEmailView(view)("/src/Views/Alerts/TestResult.cshtml", email.Body);
            //return this.SelectEmailView(EmailView.Original)(null, email.Body);
        }
    }

    public abstract class CustomRazorPage : RazorPage<TestResultBody>
    {
        //public string CustomText { get; } = "Gardyloo! - A Scottish warning yelled from a window before dumping a slop bucket on the street below.";
    }
}
