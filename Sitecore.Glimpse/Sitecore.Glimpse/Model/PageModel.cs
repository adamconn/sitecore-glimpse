using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Layouts;

namespace Sitecore.Glimpse.Model
{
    public class PageModel
    {
        public PageModel()
        {
            this.Page = Sitecore.Context.Page;
        }
        public PageContext Page { get; set; }
    }
}