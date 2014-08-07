using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Tab.Assist;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Resources.Media;

namespace Sitecore.Glimpse.Pipelines
{
    public abstract class BaseGetSection<TDataModel, TSectionModel> : IGetSectionProcessor<TDataModel>
    {
        protected BaseGetSection()
        {
            this.ImageHeight = 16;
            this.ImageWidth = 16;
        }

        protected int ImageHeight { get; set; }
        protected int ImageWidth { get; set; }
        protected virtual string GetImage(string icon)
        {
            return ThemeManager.GetImage(icon, this.ImageWidth, this.ImageHeight);
        }
        protected virtual string GetImage(ThumbnailField field)
        {
            var options = new MediaUrlOptions(16, 16, false);
            var url = MediaManager.GetMediaUrl(field.MediaItem, new MediaUrlOptions(this.ImageWidth, this.ImageHeight, false));
            return string.Format("<img src=\"{0}\" alt=\"{1}\" border=\"0\"/>", url, field.Alt);
        }
        protected virtual string GetImage(Item item)
        {
            return ThemeManager.GetIconImage(item, this.ImageWidth, this.ImageHeight, string.Empty, string.Empty);
        }
        protected virtual string GetImage(Language language, Database database)
        {
            return ThemeManager.GetLanguageImage(language, database, this.ImageWidth, this.ImageHeight);
        }
        protected abstract List<TSectionModel> GetSectionData(GlimpsePipelineArgs<TDataModel> args);

        public abstract string SectionName { get; }

        public virtual void Process(GlimpsePipelineArgs<TDataModel> args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.ArgumentNotNull(args.DataModel, "args.DataModel");
            Assert.ArgumentNotNull(args.TabObject, "args.TabObject");
            var tab = args.TabObject;
            var data = this.GetSectionData(args);
            AddSectionDataToTab(data, tab);
        }
        protected virtual void AddSectionDataToTab(List<TSectionModel> sectionModels, TabObject tab)
        {
            if (sectionModels != null && sectionModels.Count > 0)
            {
                tab.AddRow().Key(this.SectionName).Value(sectionModels);
            }
        }
    }
}