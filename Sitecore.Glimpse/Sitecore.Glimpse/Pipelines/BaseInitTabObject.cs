using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Tab.Assist;
using Sitecore.Diagnostics;

namespace Sitecore.Glimpse.Pipelines
{
    public abstract class BaseInitTabObject<TDataModel>
    {
        public virtual void Process(GlimpsePipelineArgs<TDataModel> args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.ArgumentNotNull(args.DataModel, "args.DataModel");
            if (args.TabObject == null)
            {
                args.TabObject = new TabObject();
            }
        }
    }
}