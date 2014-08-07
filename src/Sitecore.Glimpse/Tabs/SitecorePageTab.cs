using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Tabs
{
    public class SitecorePageTab : PipelineTab<PageModel>
    {
        public override string Name
        {
            get { return "Sitecore Page"; }
        }

        public override string DataPipelineName
        {
            get { return "glimpse.GetPageTabData"; }
        }

        public override string LayoutPipelineName
        {
            get { return "glimpse.InitPageTabLayout"; }
        }

        public override string Key
        {
            get { return "glimpse_sitecore_page"; }
        }
    }
}