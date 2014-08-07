namespace Sitecore.Glimpse.Pipelines.InitMvcPageTabLayout
{
    using System;
    using global::Glimpse.Core.Tab.Assist;
    using Sitecore.Glimpse.Model;
    using Sitecore.Glimpse.Pipelines;

    /// <summary>
    /// The rendering section handler setter.
    /// </summary>
    public class SetRenderingsSectionHandlers : BaseSetSectionHandlers<MvcPageModel>
    {
        /// <summary>
        /// Gets the row handler.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        /// <returns>The row handler.</returns>
        protected override Action<TabLayoutRow> GetRowHandler(string sectionName)
        {
            return this.RowHandler;
        }

        /// <summary>
        /// Rows the handler.
        /// </summary>
        /// <param name="tabLayoutRow">The tab layout row.</param>
        private void RowHandler(TabLayoutRow tabLayoutRow)
        {
            tabLayoutRow.Cell("!{{icon}}!").WithTitle("!&nbsp;!").WidthInPixels(20);
            tabLayoutRow.Cell("name").WithTitle("Rendering").AsKey();
            tabLayoutRow.Cell("placeholder").WithTitle("Placeholder");
            tabLayoutRow.Cell("dataSource").WithTitle("Data source").WidthInPixels(100);
            tabLayoutRow.Cell("details").WithTitle("Details").LimitTo(1);
        }
    }
}