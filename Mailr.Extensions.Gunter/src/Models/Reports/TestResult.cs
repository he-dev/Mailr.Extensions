using System.Collections.Generic;
using System.Linq.Custom;
using JetBrains.Annotations;
using Mailr.Extensions.Abstractions;
using Mailr.Extensions.Annotations;
using Mailr.Extensions.Models;

namespace Mailr.Extensions.Gunter.Models.Reports
{
    public class TestResult
    {
        public TestResultBody Body { get; set; }

        public Footer Footer { get; set; }
    }

    [PublicAPI]
    [UsedImplicitly]
    public class TestResultBody
    {
        public List<Section> Sections { get; set; } = new List<Section>();
    }

    [PublicAPI]
    [UsedImplicitly]
    public abstract class Section : ITaggable
    {
        public HashSet<string> Tags { get; set; }
    }

    [Mailr]
    public class HeadingDto : Section
    {
        public string Text { get; set; }

        public int Level { get; set; }
    }

    [Mailr]
    public class ParagraphDto : Section
    {
        public string Text { get; set; }
    }

    [Mailr]
    public class TableDto : Section
    {
        public HtmlTable Data { get; set; }
    }
}