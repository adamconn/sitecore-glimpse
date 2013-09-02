using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Tab.Assist;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.InitAnalyticsTabLayout
{
    public class SetGoalsSectionHandlers : BaseSetSectionHandlers<AnalyticsModel>
    {
        protected override Action<TabLayoutRow> GetRowHandler(string sectionName)
        {
            return RowHandler;
        }
        private void RowHandler(TabLayoutRow tabLayoutRow)
        {
            tabLayoutRow.Cell("!{{icon}}!").WithTitle("!&nbsp;!").WidthInPixels(20);
            tabLayoutRow.Cell("name").WithTitle("Name").AsKey().AlignRight().WidthInPixels(150);
            tabLayoutRow.Cell("count").WithTitle("Count").WidthInPixels(40);
            tabLayoutRow.Cell("goalEvents").WithTitle("Events").LimitTo(1);
        }
    }
}