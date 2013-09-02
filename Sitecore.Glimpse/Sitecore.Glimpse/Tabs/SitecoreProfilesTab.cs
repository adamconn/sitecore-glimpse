using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Tabs
{
    public class SitecoreProfilesTab : PipelineTab<ProfilesModel> 
    {
        public override string Name
        {
            get { return "Sitecore Profiles"; }
        }

        public override string DataPipelineName
        {
            get { return "glimpse.GetProfilesTabData"; }
        }

        public override string LayoutPipelineName
        {
            get { return null; }
        }

        public override string Key
        {
            get { return "glimpse_sitecore_profiles"; }
        }
    }
}