using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertAnalyticsModel
{
    public class GetVisitorSection : BaseGetSection<AnalyticsModel, SectionModel>
    {
        public override string SectionName
        {
            get { return "Visitor"; }
        }

        protected override List<SectionModel> GetSectionData(GlimpsePipelineArgs<AnalyticsModel> args)
        {
            var defaultIcon = this.GetImage("People/16x16/megaphone.png");
            var visitor = args.DataModel.Visitor;
            var list = new List<SectionModel>();
            list.Add(new SectionModel()
            {
                Icon = defaultIcon,
                Api = "Sitecore.Analytics.Tracker.Visitor.AuthenticationLevel",
                Key = "Authentication level",
                Value = visitor.AuthenticationLevel.ToString()
            });
            list.Add(new SectionModel()
            {
                Icon = defaultIcon,
                Api = "Sitecore.Analytics.Tracker.Visitor.CookieVisitId",
                Key = "Visit ID (cookie)",
                Value = visitor.CookieVisitId.ToString()
            });
            list.Add(new SectionModel()
            {
                Icon = defaultIcon,
                Api = "Sitecore.Analytics.Tracker.Visitor.ExternalUser",
                Key = "External user",
                Value = visitor.ExternalUser
            });
            list.Add(new SectionModel()
            {
                Icon = defaultIcon,
                Api = "Sitecore.Analytics.Tracker.Visitor.HasCurrentVisit",
                Key = "Has current visit",
                Value = visitor.HasCurrentVisit.ToString()
            });
            list.Add(new SectionModel()
            {
                Icon = defaultIcon,
                Api = "Sitecore.Analytics.Tracker.Visitor.IsSubmitDisabled",
                Key = "Submit disabled",
                Value = visitor.IsSubmitDisabled.ToString()
            });
            if (visitor.HasCurrentVisit)
            {
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.VisitorId",
                    Key = "Visitor ID",
                    Value = visitor.VisitorId.ToString()
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.VisitCount",
                    Key = "Visit count",
                    Value = visitor.VisitCount.ToString()
                });
                //list.Add(new SectionItemModel()
                //{
                //    //Icon = ThemeManager.GetLanguageImage(model.Language, model.Database, 16, 16),
                //    Api = "Sitecore.Analytics.Tracker.Visitor.Settings.IsFirstRequest",
                //    Key = "IsFirstRequest",
                //    Value = visitor.Settings.IsFirstRequest.ToString()
                //});
                //list.Add(new SectionItemModel()
                //{
                //    //Icon = ThemeManager.GetLanguageImage(model.Language, model.Database, 16, 16),
                //    Api = "Sitecore.Analytics.Tracker.Visitor.Settings.IsNew",
                //    Key = "IsNew",
                //    Value = visitor.Settings.IsNew.ToString()
                //});
                //list.Add(new SectionItemModel()
                //{
                //    //Icon = ThemeManager.GetLanguageImage(model.Language, model.Database, 16, 16),
                //    Api = "Sitecore.Analytics.Tracker.Visitor.Settings.IsTransient",
                //    Key = "IsTransient",
                //    Value = visitor.Settings.IsTransient.ToString()
                //});
                //list.Add(new SectionItemModel()
                //{
                //    //Icon = ThemeManager.GetLanguageImage(model.Language, model.Database, 16, 16),
                //    Api = "Sitecore.Analytics.Tracker.Visitor.Settings.IsVisitorClassificationGuessed",
                //    Key = "IsVisitorClassificationGuessed",
                //    Value = visitor.Settings.IsVisitorClassificationGuessed.ToString()
                //});
                //
            }
            return list;
        }
    }
}