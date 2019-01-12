using System.Collections.Generic;
using JetBrains.Annotations;
using Mailr.Extensions.Gunter.Models.Alerts;
using Mailr.Extensions.Models;
using Mailr.Extensions.Utilities.Mvc;
using Mailr.Extensions.Utilities.Mvc.Filters;
using Mailr.Extensions.Utilities.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Reusable.OmniLog.Mvc.Filters;
using Reusable.Utilities.AspNetCore.ActionFilters;

namespace Mailr.Extensions.Gunter.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/gunter/[controller]")]
    [Extension]
    [ApiController]
    public class AlertsController : Controller
    {
        private static readonly TestResultBody TestResultBody = new TestResultBody
        {
            Modules =
            {
                ["Level"] = new Level
                {
                    Text = "Debug",
                    Ordinal = 1
                },
                ["Greeting"] = new Greeting
                {
                    Heading = "Hi, everyone.",
                    Text = "It appears to be something wrong with Gunter-v3.0.0.",
                    Ordinal = 2
                },
                ["TestCase"] = new TestCase
                {
                    Heading = "Test Case",
                    Table = new Table
                    {
                        Head = new List<IList<object>>(),
                        Body = new []
                        {
                            new [] { "Filter", "none" },
                            new [] { "Expression", "Count([Id]) > 0" },
                            new [] { "Assert", "True" },
                            new [] { "OnPassed", "Halt, Alert" },
                            new [] { "OnFailed", "Halt" },
                            new [] { "AssertElapsed", "00:00.000" },
                            new [] { "Profiles", "[]" },

                        }
                    },
                    Ordinal = 3
                },
                ["DataSource"] = new DataSource
                {
                    Heading = "Data Source",
                    Table = new Table
                    {
                        Head = new List<IList<object>>(),
                        Body = new []
                        {
                            new [] { "Type", "TableOrView" },
                            new [] { "Query: Main", "SELECT * FROM [dbo].[SemLog]" },
                            new [] { "RowCount", "1198" },
                            new [] { "Elapsed", "00:00.092" },
                            new [] { "Timestamp: min", "11/23/2017 19:54:50" },
                            new [] { "Timestamp: max", "11/27/2017 21:01:46" },
                            new [] { "Timespan", "06:56.266" },
                        }
                    },
                    Ordinal = 4
                },
                ["DataSummary"] = new DataSummary
                {
                    Table = new Table
                    {
                        Head = new List<IList<object>>
                        {
                            new List<object>
                            {
                                "Product",
                                "Transaction",
                                "Elapsed",
                                "Event",
                                "Result",
                                "Exception",
                                "RowCount"
                            }
                        },
                        Body = new []
                        {
                            new []
                            {
                                "Gunter-v3.0.0",
                                "",
                                "",
                                "InitializeLogging",
                                "Success",
                                "System.ArgumentException: The type 'Gunter.Services.TestLoader' is not assignable to service 'Gunter.Services.ITestLoader'.",
                                "768"
                            }
                        }
                    },
                    Ordinal = 5
                }
            }
        };

        //// http://localhost:49471/api/gunter/runtest/result
        //[HttpGet("[action]")]
        //public IActionResult TestResult([FromQuery] EmailView view)
        //{
        //    return this.EmailView(view)(null, TestResultBody);
        //}

        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidateModel))]
        [ServiceFilter(typeof(SendEmail))]
        [LogResponseBody]
        public IActionResult TestResult([FromBody] Email<TestResultBody> email, [ModelBinder(typeof(EmailViewBinder))] EmailView view)
        {
            return this.SelectEmailView(view)(null, email.Body);
        }
    }
}
