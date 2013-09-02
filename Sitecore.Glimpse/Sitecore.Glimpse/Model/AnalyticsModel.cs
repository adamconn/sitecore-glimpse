using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics;
using Sitecore.Analytics.Data.DataAccess;
using Sitecore.Analytics.Data.DataAccess.DataSets;
using Sitecore.Data;

namespace Sitecore.Glimpse.Model
{
    public class AnalyticsModel
    {
        public AnalyticsModel()
        {
            this.Visitor = Tracker.Visitor;
            this.CurrentVisit = Tracker.CurrentVisit;
            this.Database = Sitecore.Context.Database;
            this.DataContext = Tracker.DataContext;
        }
        public Visitor Visitor { get; set; }
        public VisitorDataSet.VisitsRow CurrentVisit { get; set; }
        public Database Database { get; set; }
        public TrackerDataContext DataContext { get; set; }
    }
}