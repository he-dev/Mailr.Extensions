using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

[assembly: AspMvcViewLocationFormat("/src/Views/{1}/{0}.cshtml")]
[assembly: AspMvcPartialViewLocationFormat("/src/Views/{1}/{0}.cshtml")]
