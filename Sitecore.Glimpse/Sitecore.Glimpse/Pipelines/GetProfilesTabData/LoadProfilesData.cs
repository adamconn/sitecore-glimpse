using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics;
using Sitecore.Analytics.Data.DataAccess;
using Sitecore.Diagnostics;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.GetProfilesTabData
{
    public class LoadProfilesData
    {
        public void Process(GlimpsePipelineArgs<ProfilesModel> args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.ArgumentNotNull(args.TabData, "args.TabData");
            Tracker.Visitor.LoadAll(VisitLoadOptions.Profiles, VisitorOptions.Visitor);
        }
    }
}