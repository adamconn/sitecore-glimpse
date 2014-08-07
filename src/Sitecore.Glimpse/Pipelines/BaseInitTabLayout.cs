using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Tab.Assist;
using Sitecore.Diagnostics;

namespace Sitecore.Glimpse.Pipelines
{
    public abstract class BaseInitTabLayout<TDataModel>
    {
        public virtual void Process(GlimpsePipelineArgs<TDataModel> args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.ArgumentNotNull(args.SectionHandlers, "args.SectionHandlers");
            var layout = TabLayout.Create();
            foreach (var name in args.SectionHandlers.Keys)
            {
                layout.Cell(name, TabLayout.Create().Row(args.SectionHandlers[name]));
            }
            args.TabLayout = layout;
        }
    }
}