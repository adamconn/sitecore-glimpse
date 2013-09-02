using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertContextModel
{
    public class GetItemSection : BaseGetSection<ContextModel, SectionModel>
    {
        public override string SectionName
        {
            get { return "Item"; }
        }

        protected override List<SectionModel> GetSectionData(GlimpsePipelineArgs<ContextModel> args)
        {
            var item = args.DataModel.Item;
            var list = new List<SectionModel>();
            list.Add(new SectionModel()
            {
                Icon = this.GetImage(item),
                Api = "Sitecore.Context.Item",
                Key = "Item",
                Value = item.Paths.Path
            });
            list.Add(new SectionModel()
            {
                Icon = this.GetImage(item),
                Api = "Sitecore.Context.Item.ID",
                Key = "Item ID",
                Value = item.ID.ToString()
            });
            list.Add(new SectionModel()
            {
                Icon = this.GetImage(item.Template.InnerItem),
                Api = "Sitecore.Context.Item.Template",
                Key = "Template",
                Value = item.Template.InnerItem.Paths.Path
            });
            return list;
        }
    }
}