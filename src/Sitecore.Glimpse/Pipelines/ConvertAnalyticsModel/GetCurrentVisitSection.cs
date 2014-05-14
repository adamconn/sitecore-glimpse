using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertAnalyticsModel
{
    public class GetCurrentVisitSection : BaseGetSection<AnalyticsModel, SectionModel>
    {
        public override string SectionName
        {
            get { return "Current Visit"; }
        }

        protected override List<SectionModel> GetSectionData(GlimpsePipelineArgs<AnalyticsModel> args)
        {
            var defaultIcon = this.GetImage("People/16x16/megaphone.png");
            var visit = args.DataModel.Visitor.CurrentVisit;
            var list = new List<SectionModel>();
            if (visit != null)
            {
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.AspNetSessionId",
                    Key = "Asp.NET session ID",
                    Value = visit.AspNetSessionId
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.HasGeoIpData",
                    Key = "Has geo IP data",
                    Value = visit.HasGeoIpData.ToString()
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.Ip",
                    Key = "IP address",
                    Value = new IPAddress(visit.Ip).ToString()
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.Referrer",
                    Key = "Referrer",
                    Value = visit.Referrer
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.StartDateTime",
                    Key = "Visit start",
                    Value = visit.StartDateTime.ToString()
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = null,
                    Key = "Visit duration",
                    Value = DateTime.Now.Subtract(visit.StartDateTime).ToString(@"d\.h\:mm\:ss")
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.VisitId",
                    Key = "Visit ID",
                    Value = visit.VisitId.ToString()
                });
            }
            return list;
        }
    }
}