using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Glimpse.Pipelines
{
    public interface IGetSectionProcessor<TDataModel>
    {
        string SectionName { get; }
        void Process(GlimpsePipelineArgs<TDataModel> args);
    }
}
