using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Tab.Assist;
using Sitecore.Data;
using Sitecore.Pipelines;

namespace Sitecore.Glimpse.Pipelines
{
    public class GlimpsePipelineArgs<T> : PipelineArgs
    {
        public object TabData { get; set; }
        public TabLayout TabLayout { get; set; }
        public T DataModel { get; set; }
        public TabObject TabObject { get; set; }
        public Dictionary<string, Action<TabLayoutRow>> SectionHandlers { get; set; } 
    }
}