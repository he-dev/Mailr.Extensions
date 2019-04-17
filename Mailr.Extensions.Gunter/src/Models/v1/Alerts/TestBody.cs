using System.Collections.Generic;
using Mailr.Extensions.Gunter.Json;
using Mailr.Extensions.Models;
using Newtonsoft.Json;

namespace Mailr.Extensions.Gunter.Models.v1.Alerts
{
    public class TestResultBody
    {
        //public string Theme { get; set; }

        [JsonConverter(typeof(DictionaryConverter<Module>))]
        public IDictionary<string, Module> Modules { get; set; } = new Dictionary<string, Module>();
    }

    public abstract class Module
    {
        public string Heading { get; set; }

        public string Text { get; set; }

        public int Ordinal { get; set; }

        public HtmlTable Data { get; set; }
    }

    public class Level : Module { }

    public class Greeting : Module { }

    public class TestCase : Module { }

    public class DataSource : Module { }

    public class DataSummary : Module { }

    public class Signature : Module { }    
}
