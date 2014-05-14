using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertContextModel
{
    public class GetPageSection : BaseGetSection<ContextModel, SectionModel>
    {
        public override string SectionName
        {
            get { return "Page"; }
        }

        protected override List<SectionModel> GetSectionData(GlimpsePipelineArgs<ContextModel> args)
        {
            var page = args.DataModel.Page;
            var list = new List<SectionModel>();
            list.Add(new SectionModel()
            {
                Icon = this.GetImage(args.DataModel.Device.Icon),
                Api = "Sitecore.Context.Device",
                Key = "Device",
                Value = args.DataModel.Device.Name
            });
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