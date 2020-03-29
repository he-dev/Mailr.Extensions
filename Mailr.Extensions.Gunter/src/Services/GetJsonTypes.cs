using System;
using System.Collections.Generic;
using Mailr.Extensions.Gunter.Models.Reports;
using Reusable.Utilities.JsonNet.Abstractions;

namespace Mailr.Extensions.Gunter.Services
{
    public class GetJsonTypes : IGetJsonTypes
    {
        public IEnumerable<Type> Execute()
        {
            yield return typeof(HeadingDto);
            yield return typeof(ParagraphDto);
            yield return typeof(TableDto);
        }
    }
}