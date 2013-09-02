using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Tabs
{
    public class SitecoreAnalyticsTab : PipelineTab<AnalyticsModel>
    {
        public override string Name
        {
            get { return "Sitecore Analytics"; }
        }

        public override string DataPipelineName
        {
            get { return "glimpse.GetAnalyticsTabData"; }
        }

        public override string LayoutPipelineName
        {
            get { return "glimpse.InitAnalyticsTabLayout"; }
        }

        public override string Key
        {
            get { return "glimpse_sitecore_analytics";  }
        }
    }
}