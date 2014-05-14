using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Tab.Assist;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.InitPageTabLayout
{
    public class SetRenderingsSectionHandlers : BaseSetSectionHandlers<PageModel>
    {
        protected override Action<TabLayoutRow> GetRowHandler(string sectionName)
        {
            return RowHandler;
        }
        private void RowHandler(TabLayoutRow tabLayoutRow)
        {
            tabLayoutRow.Cell("!{{icon}}!").WithTitle("!&nbsp;!").WidthInPixels(20);
            tabLayoutRow.Cell("name").WithTitle("Rendering").AsKey();
            tabLayoutRow.Cell("placeholder").WithTitle("Placeholder");
            tabLayoutRow.Cell("dataSource").WithTitle("Data source").WidthInPixels(100);
            tabLayoutRow.Cell("details").WithTitle("Details").LimitTo(1);
            tabLayoutRow.Cell("settings").WithTitle("Settings").LimitTo(1);
        }
    }
}