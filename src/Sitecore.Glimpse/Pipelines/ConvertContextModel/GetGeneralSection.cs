using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertContextModel
{
    public class GetGeneralSection : BaseGetSection<ContextModel, SectionModel>
    {
        public override string SectionName
        {
            get { return "General"; }
        }

        protected override List<SectionModel> GetSectionData(GlimpsePipelineArgs<ContextModel> args)
        {
            var model = args.DataModel;
            var list = new List<SectionModel>();
            list.Add(new SectionModel()
            {
                Icon = this.GetImage("Business/16x16/data.png"),
                Api = "Sitecore.Context.Database",
                Key = "Database",
                Value = model.Database.Name
            });
            list.Add(new SectionModel()
            {
                Icon = this.GetImage(args.DataModel.Device.Icon),
                Api = "Sitecore.Context.Device",
                Key = "Device",
                Value = args.DataModel.Device.Name
            });
            list.Add(new SectionModel()
            {
                Icon = this.GetImage(model.Language, model.Database),
                Api = "Sitecore.Context.Language",
                Key = "Language",
                Value = model.Language.Name
            });
            list.Add(new SectionModel()
            {
                Icon = this.GetImage("Network/16x16/home.png"),
                Api = "Sitecore.Context.Site",
                Key = "Site",
                Value = model.Site.Name
            });
            return list;
        }
    }
}