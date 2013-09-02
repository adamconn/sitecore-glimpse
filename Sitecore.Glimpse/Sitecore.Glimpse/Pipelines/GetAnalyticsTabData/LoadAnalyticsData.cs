using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics;
using Sitecore.Analytics.Data.DataAccess;
using Sitecore.Diagnostics;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.GetAnalyticsTabData
{
    public class LoadAnalyticsData
    {
        public void Process(GlimpsePipelineArgs<AnalyticsModel> args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.ArgumentNotNull(args.TabData, "args.TabData");
            Tracker.Visitor.LoadAll(VisitLoadOptions.PageEvents, VisitorOptions.Visitor);
        }
    }
}