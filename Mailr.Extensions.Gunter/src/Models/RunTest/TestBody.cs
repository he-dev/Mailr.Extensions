using System.Collections.Generic;
using Mailr.Extensions.Gunter.Json;
using Newtonsoft.Json;

namespace Mailr.Extensions.Gunter.Models.RunTest
{
    public class ResultBody
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

        public Table Table { get; set; }
    }

    public class Level : Module { }

    public class Greeting : Module { }

    public class TestCase : Module { }

    public class DataSource : Module { }

    public class DataSummary : Module { }

    public class Signature : Module { }

    public class Table
    {
        public IList<IList<object>> Head { get; set; }

        public IList<IList<object>> Body { get; set; }

        public IList<IList<object>> Foot { get; set; }
    }
}
