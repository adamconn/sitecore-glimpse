using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics;
using Sitecore.Analytics.Data.DataAccess.DataSets;
using Sitecore.Data;

namespace Sitecore.Glimpse.Model
{
    public class ProfilesModel
    {
        public ProfilesModel()
        {
            this.Profiles = Tracker.CurrentVisit.Profiles;
            this.Database = Sitecore.Context.Database;
        }
        public IEnumerable<VisitorDataSet.ProfilesRow> Profiles { get; set; }
        public Database Database { get; set; }
    }
}