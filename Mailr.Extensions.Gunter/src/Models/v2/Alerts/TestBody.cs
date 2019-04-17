using System.Collections.Generic;
using JetBrains.Annotations;
using Mailr.Extensions.Gunter.Json;
using Mailr.Extensions.Models;
using Newtonsoft.Json;
using Reusable.Utilities.JsonNet.Converters;

namespace Mailr.Extensions.Gunter.Models.v2.Alerts
{
    [PublicAPI]
    [UsedImplicitly]
    public class TestResultBody
    {
        [JsonConverter(typeof(ListConverter<Module>))]
        public List<Module> Modules { get; set; } = new List<Module>();
    }

    [PublicAPI]
    [UsedImplicitly]
    public abstract class Module
    {
        [JsonIgnore]
        public string Name => GetType().Name;
        
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
