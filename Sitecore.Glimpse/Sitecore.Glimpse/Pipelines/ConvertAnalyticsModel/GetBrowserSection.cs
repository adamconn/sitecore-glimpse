using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertAnalyticsModel
{
    public class GetBrowserSection : BaseGetSection<AnalyticsModel, SectionModel>
    {
        public override string SectionName
        {
            get { return "Browser"; }
        }

        protected override List<SectionModel> GetSectionData(GlimpsePipelineArgs<AnalyticsModel> args)
        {
            var defaultIcon = this.GetImage("People/16x16/megaphone.png");
            var visit = args.DataModel.Visitor.CurrentVisit;
            var list = new List<SectionModel>();
            if (visit != null)
            {
                var browser = visit.Browser;
                if (browser != null)
                {
                    list.Add(new SectionModel()
                    {
                        Icon = defaultIcon,
                        Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.Browser.BrowserId",
                        Key = "Browser ID",
                        Value = browser.BrowserId.ToString()
                    });
                    list.Add(new SectionModel()
                    {
                        Icon = defaultIcon,
                        Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.Browser.MajorName",
                        Key = "Major name",
                        Value = browser.MajorName
                    });
                    list.Add(new SectionModel()
                    {
                        Icon = defaultIcon,
                        Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.Browser.MinorName",
                        Key = "Minor name",
                        Value = browser.MinorName
                    });

                }
            }
            return list;
        }
    }
}