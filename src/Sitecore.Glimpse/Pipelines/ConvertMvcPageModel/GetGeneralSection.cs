namespace Sitecore.Glimpse.Pipelines.ConvertMvcPageModel
{
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore.Glimpse.Model;
    using Sitecore.Glimpse.Pipelines;

    /// <summary>
    /// The general section class.
    /// </summary>
    public class GetGeneralSection : BaseGetSection<MvcPageModel, SectionModel>
    {
        /// <summary>
        /// Gets the name of the section.
        /// </summary>
        /// <value>
        /// The name of the section.
        /// </value>
        public override string SectionName
        {
            get
            {
                return "General";
            }
        }

        /// <summary>
        /// Gets the section data.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>The section model.</returns>
        protected override List<SectionModel> GetSectionData(GlimpsePipelineArgs<MvcPageModel> args)
        {
            var layout = args.DataModel.Layout;
            var page = args.DataModel.Page;
            return new List<SectionModel>
                       {
                           new SectionModel 
                           {
                               Icon = this.GetImage("Applications/16x16/window.png"),
                               Api = "Sitecore.Context.Page.FilePath",
                               Key = "Layout file",
                               Value = layout
                           },
                           new SectionModel 
                           {
                               Icon = this.GetImage("Business/16x16/table_selection_block.png"),
                               Api = "PageContext.Current.PageDefinition.Renderings.Select(r => r.Placeholder)",
                               Key = "Placeholders",
                               Value = string.Join("\n", page.PageDefinition.Renderings.Where(r => !string.IsNullOrWhiteSpace(r.Placeholder)).Select(r => r.Placeholder).Distinct())
                           }
                       };
        }
    }
}