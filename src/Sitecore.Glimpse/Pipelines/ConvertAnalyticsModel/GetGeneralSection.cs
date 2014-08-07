using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics.Configuration;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertAnalyticsModel
{
    public class GetGeneralSection : BaseGetSection<AnalyticsModel, SectionModel>
    {
        public override string SectionName
        {
            get { return "General"; }
        }
        protected override List<SectionModel> GetSectionData(GlimpsePipelineArgs<AnalyticsModel> args)
        {
            var defaultIcon = this.GetImage("Applications/16x16/preferences.png");
            var model = args.DataModel;
            var list = new List<SectionModel>();
            list.Add(new SectionModel()
            {
                Icon = defaultIcon,
                Api = "Sitecore.Analytics.Configuration.AnalyticsSettings.DisableDatabase",
                Key = "Database disabled",
                Value = AnalyticsSettings.DisableDatabase.ToString()
            });
            list.Add(new SectionModel()
            {
                Icon = defaultIcon,
                Api = "Sitecore.Analytics.Configuration.AnalyticsSettings.Enabled",
                Key = "Analytics enabled",
                Value = AnalyticsSettings.Enabled.ToString()
            });
            return list;
        }
    }
}