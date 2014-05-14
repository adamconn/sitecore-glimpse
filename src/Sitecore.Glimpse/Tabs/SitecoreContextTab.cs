using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Tabs
{
    public class SitecoreContextTab : PipelineTab<ContextModel>
    {
        public override string Name
        {
            get { return "Sitecore Context"; }
        }
        
        public override string DataPipelineName
        {
            get { return "glimpse.GetContextTabData"; }
        }

        public override string LayoutPipelineName
        {
            get { return "glimpse.InitContextTabLayout"; }
        }

        public override string Key
        {
            get { return "glimpse_sitecore_context";  }
        }
    }
}