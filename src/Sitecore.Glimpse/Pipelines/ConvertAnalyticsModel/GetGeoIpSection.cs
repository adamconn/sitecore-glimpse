using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertAnalyticsModel
{
    public class GetGeoIpSection : BaseGetSection<AnalyticsModel, SectionModel>
    {
        public override string SectionName
        {
            get { return "Geo IP"; }
        }

        protected override List<SectionModel> GetSectionData(GlimpsePipelineArgs<AnalyticsModel> args)
        {
            var defaultIcon = this.GetImage("People/16x16/megaphone.png");
            var visit = args.DataModel.Visitor.CurrentVisit;
            var list = new List<SectionModel>();
            if (visit != null && visit.HasGeoIpData)
            {
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.AreaCode",
                    Key = "Area code",
                    Value = visit.AreaCode
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.City",
                    Key = "City",
                    Value = visit.City
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.Country",
                    Key = "Country",
                    Value = visit.Country
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.IspName",
                    Key = "ISP name",
                    Value = visit.IspName
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.Latitude",
                    Key = "Latitude",
                    Value = visit.Latitude.ToString()
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.LocationId",
                    Key = "Location ID",
                    Value = visit.LocationId.ToString()
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.Longitude",
                    Key = "Longitude",
                    Value = visit.Longitude.ToString()
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.MetroCode",
                    Key = "Metro code",
                    Value = visit.MetroCode
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.PostalCode",
                    Key = "Postal code",
                    Value = visit.PostalCode
                });
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = "Sitecore.Analytics.Tracker.Visitor.CurrentVisit.Region",
                    Key = "Region",
                    Value = visit.Region
                });
            }
            return list;
        }
    }
}