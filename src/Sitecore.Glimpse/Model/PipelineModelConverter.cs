using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Extensibility;
using Sitecore.Pipelines;
using Sitecore.Glimpse.Pipelines;

namespace Sitecore.Glimpse.Model
{
    public abstract class PipelineModelConverter<TModel> : SerializationConverter<TModel>
    {
        public abstract string PipelineName { get; }
        public override object Convert(TModel model)
        {
            var args = new GlimpsePipelineArgs<TModel>();
            args.DataModel = model;
            CorePipeline.Run(this.PipelineName, args);
            return args.TabObject.Build();
        }
    }
}