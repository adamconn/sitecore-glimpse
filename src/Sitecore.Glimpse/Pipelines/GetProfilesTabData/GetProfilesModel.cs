using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.GetProfilesTabData
{
    public class GetProfilesModel
    {
        public void Process(GlimpsePipelineArgs<ProfilesModel> args)
        {
            Assert.ArgumentNotNull(args, "args");
            var data = new ProfilesModel();
            args.TabData = data;
        }
    }
}