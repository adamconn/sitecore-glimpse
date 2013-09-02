using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.GetPageTabData
{
    public class GetPageModel
    {
        public void Process(GlimpsePipelineArgs<PageModel> args)
        {
            Assert.ArgumentNotNull(args, "args");
            var data = new PageModel();
            args.TabData = data;
        }
    }
}