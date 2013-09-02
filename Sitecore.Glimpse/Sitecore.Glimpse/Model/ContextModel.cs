using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Layouts;
using Sitecore.Security.Accounts;
using Sitecore.Sites;

namespace Sitecore.Glimpse.Model
{
    public class ContextModel
    {
        public ContextModel()
        {
            this.Language = Sitecore.Context.Language;
            this.Database = Sitecore.Context.Database;
            this.Device = Sitecore.Context.Device;
            this.Item = Sitecore.Context.Item;
            this.User = Sitecore.Context.User;
            this.Site = Sitecore.Context.Site;
            this.Page = Sitecore.Context.Page;
        }
        public Language Language { get; set; }
        public Database Database { get; set; }
        public DeviceItem Device { get; set; }
        public Item Item { get; set; }
        public User User { get; set; }
        public SiteContext Site { get; set; }
        public PageContext Page { get; set; }
    }
}