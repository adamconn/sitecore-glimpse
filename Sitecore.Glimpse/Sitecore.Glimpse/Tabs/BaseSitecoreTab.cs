using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.AspNet.Extensibility;
using Glimpse.Core.Extensibility;

namespace Sitecore.Glimpse.Tabs
{
    public abstract class BaseSitecoreTab<TDataModel> : AspNetTab, IDocumentation, IKey, ILayoutControl, ITabLayout
    {
        public virtual string DocumentationUri { get { return "https://github.com/adamconn/sitecore-glimpse/wiki/"; } }
        public abstract string Key { get; }
        public virtual bool KeysHeadings { get { return true; } }
        public override RuntimeEvent ExecuteOn
        {
            get { return RuntimeEvent.EndSessionAccess; }
        }
        public abstract object GetLayout();
    }
}