using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.GetAnalyticsTabData
{
    public class GetAnalyticsModel
    {
        public void Process(GlimpsePipelineArgs<AnalyticsModel> args)
        {
            Assert.ArgumentNotNull(args, "args");
            var data = new AnalyticsModel();
            args.TabData = data;
        }
    }
}