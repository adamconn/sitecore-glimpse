using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.GetContextTabData
{
    public class GetContextModel
    {
        public void Process(GlimpsePipelineArgs<ContextModel> args)
        {
            Assert.ArgumentNotNull(args, "args");
            var data = new ContextModel();
            args.TabData = data;
        }
    }
}