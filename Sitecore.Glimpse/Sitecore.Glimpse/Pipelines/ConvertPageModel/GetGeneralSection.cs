using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertPageModel
{
    public class GetGeneralSection : BaseGetSection<PageModel, SectionModel>
    {
        public override string SectionName
        {
            get { return "General"; }
        }

        protected override List<SectionModel> GetSectionData(GlimpsePipelineArgs<PageModel> args)
        {
            var page = args.DataModel.Page;
            var list = new List<SectionModel>();
            list.Add(new SectionModel()
            {
                Icon = this.GetImage("Applications/16x16/window.png"),
                Api = "Sitecore.Context.Page.FilePath",
                Key = "Layout file",
                Value = page.FilePath
            });
            list.Add(new SectionModel()
            {
                Icon = this.GetImage("Business/16x16/table_selection_block.png"),
                Api = "Sitecore.Context.Page.Placeholders",
                Key = "Placeholders",
                Value = String.Join("\n", page.Placeholders.Select(ph => ph.ContextKey).ToArray())
            });
            return list;
        }
    }
}