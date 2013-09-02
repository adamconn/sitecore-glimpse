using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Extensibility;
using Sitecore.Pipelines;
using Sitecore.Glimpse.Pipelines;

namespace Sitecore.Glimpse.Tabs
{
    public abstract class PipelineTab<TDataModel> : BaseSitecoreTab<TDataModel>
    {
        public abstract string DataPipelineName { get; }
        public abstract string LayoutPipelineName { get; }
        public override object GetData(ITabContext context)
        {
            var args = new GlimpsePipelineArgs<TDataModel>();
            CorePipeline.Run(this.DataPipelineName, args);
            return args.TabData;
        }
        public override object GetLayout()
        {
            var args = new GlimpsePipelineArgs<TDataModel>();
            if (! string.IsNullOrEmpty(this.LayoutPipelineName))
            {
                CorePipeline.Run(this.LayoutPipelineName, args);
                if (args.TabLayout != null)
                {
                    return args.TabLayout.Build();
                }
            }
            return null;
        }
    }
}