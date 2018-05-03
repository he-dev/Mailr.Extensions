using System.Collections.Generic;
using Mailr.Extensions.Gunter.Json;
using Newtonsoft.Json;

namespace Mailr.Extensions.Gunter.Models.RunTest
{
    public class ResultBody
    {
        public string Theme { get; set; }

        [JsonConverter(typeof(DictionaryConverter<Module>))]
        public IDictionary<string, Module> Modules { get; set; } = new Dictionary<string, Module>();
    }    

    public abstract class Module
    {
        public string Heading { get; set; }

        public string Text { get; set; }

        public int Ordinal { get; set; }
    }

    public class Level : Module
    {
    }

    public class Greeting : Module
    {
    }

    public class Table
    {
        public IList<string> Head { get; set; }

        public IList<IList<string>> Body { get; set; }

        public IList<string> Foot { get; set; }
    }

    public class TestCase : Module
    {
        public Table Table { get; set; }
    }

    public class DataSource : Module
    {
        public Table Table { get; set; }
    }

    public class DataSummary : Module
    {
        public Table Table { get; set; }
    }

    public class Signature : Module
    {
    }
}
