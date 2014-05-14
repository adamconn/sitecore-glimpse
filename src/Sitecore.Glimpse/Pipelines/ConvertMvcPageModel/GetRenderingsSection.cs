namespace Sitecore.Glimpse.Pipelines.ConvertMvcPageModel
{
    using System.Collections.Generic;
    using Sitecore.Glimpse.Model;
    using Sitecore.Glimpse.Pipelines;

    /// <summary>
    /// The rendering details model.
    /// </summary>
    public class RenderingDetailsModel
    {
        /// <summary>
        /// Gets or sets the rendering path.
        /// </summary>
        /// <value>
        /// The rendering path.
        /// </value>
        public string RenderingPath { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public string UniqueId { get; set; }
    }

    /// <summary>
    /// The renderings section item model.
    /// </summary>
    public class RenderingSectionItemModel
    {
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the placeholder.
        /// </summary>
        /// <value>
        /// The placeholder.
        /// </value>
        public string Placeholder { get; set; }

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>
        /// The data source.
        /// </value>
        public string DataSource { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public RenderingDetailsModel Details { get; set; }
    }

    /// <summary>
    /// The get renderings section class.
    /// </summary>
    public class GetRenderingsSection : BaseGetSection<MvcPageModel, RenderingSectionItemModel>
    {
        /// <summary>
        /// Gets the name of the section.
        /// </summary>
        /// <value>
        /// The name of the section.
        /// </value>
        public override string SectionName
        {
            get { return "Renderings"; }
        }

        /// <summary>
        /// Gets the section data.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>List of rendering section models.</returns>
        protected override List<RenderingSectionItemModel> GetSectionData(GlimpsePipelineArgs<MvcPageModel> args)
        {
            var renderings = args.DataModel.Page.PageDefinition.Renderings;
            var list = new List<RenderingSectionItemModel>();
            foreach (var rendering in renderings)
            {
                if (string.IsNullOrWhiteSpace(rendering.Placeholder)) continue;

                var item = rendering.RenderingItem.InnerItem;
                var details = new RenderingDetailsModel()
                {
                    RenderingPath = item.Paths.FullPath,
                    UniqueId = rendering.UniqueId.ToString()
                };
                list.Add(new RenderingSectionItemModel()
                {
                    Icon = this.GetImage(item),
                    Name = rendering.RenderingItem.Name,
                    Placeholder = rendering.Placeholder,
                    DataSource = rendering.DataSource,
                    Details = details
                });
            }

            return list;
        }
    }
}