using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Layouts;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertPageModel
{
    public class RenderingDetailsModel
    {
        public string RenderingPath { get; set; }
        public bool AddedToPage { get; set; }
        public string UniqueId { get; set; }
    }
    public class RenderingSectionItemModel
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Placeholder { get; set; }
        public string DataSource { get; set; }
        public RenderingDetailsModel Details { get; set; }
        public RenderingSettings Settings { get; set; }
    }

    public class GetRenderingsSection : BaseGetSection<PageModel, RenderingSectionItemModel>
    {
        public override string SectionName
        {
            get { return "Renderings"; }
        }

        protected override List<RenderingSectionItemModel> GetSectionData(GlimpsePipelineArgs<PageModel> args)
        {
            var renderings = args.DataModel.Page.Renderings;
            var list = new List<RenderingSectionItemModel>();
            foreach (RenderingReference rendering in renderings)
            {
                var item = rendering.RenderingItem.InnerItem;
                var details = new RenderingDetailsModel()
                    {
                        RenderingPath = item.Paths.FullPath,
                        UniqueId = rendering.UniqueId,
                        AddedToPage = rendering.AddedToPage
                    };
                list.Add(new RenderingSectionItemModel()
                {
                    Icon = this.GetImage(item),
                    Name = rendering.RenderingItem.Name,
                    Placeholder = rendering.Placeholder,
                    DataSource = rendering.Settings.DataSource,
                    Details = details,
                    Settings = rendering.Settings
                });
            }
            return list;
        }
    }
}