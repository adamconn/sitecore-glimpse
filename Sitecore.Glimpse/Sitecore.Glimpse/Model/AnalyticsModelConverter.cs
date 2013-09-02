using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Glimpse.Model
{
    public class AnalyticsModelConverter : PipelineModelConverter<AnalyticsModel>
    {
        public override string PipelineName
        {
            get { return "glimpse.ConvertAnalyticsModel"; }
        }
    }
}