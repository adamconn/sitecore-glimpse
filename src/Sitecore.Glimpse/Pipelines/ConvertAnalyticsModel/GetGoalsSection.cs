using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Tab.Assist;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertAnalyticsModel
{
    public class GoalEventModelConverter : SerializationConverter<List<GoalEventModel>>
    {
        public override object Convert(List<GoalEventModel> obj)
        {
            var section = new TabSection(new string[] { "", "Date", "Text", "Data", "Data code", "Data key" });
            foreach (var goalEvent in obj)
            {
                section.AddRow()
                    .Column(goalEvent.Count)
                    .Column(goalEvent.DateTime)
                    .Column(goalEvent.Text)
                    .Column(goalEvent.Data)
                    .Column(goalEvent.DataCode)
                    .Column(goalEvent.DataKey);
            }
            return section.Build();
        }
    }
    public class GoalEventModel
    {
        public int Count { get; set; }
        public string DateTime { get; set; }
        public string Text { get; set; }
        public string Data { get; set; }
        public int DataCode { get; set; }
        public string DataKey { get; set; }
    }
    public class GoalSectionModel
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public List<GoalEventModel> GoalEvents { get; set; }
    }

    public class GetGoalsSection : BaseGetSection<AnalyticsModel, GoalSectionModel>
    {
        public override string SectionName
        {
            get { return "Goals"; }
        }
        
        protected override List<GoalSectionModel> GetSectionData(GlimpsePipelineArgs<AnalyticsModel> args)
        {
            var context = args.DataModel.DataContext;
            var list = new List<GoalSectionModel>();
            if (context != null)
            {
                var groupedPageEvents = context.PageEvents.GroupBy(row => row.PageEventDefinition).OrderBy(rows => rows.Key.Name);
                foreach (var pageEvents in groupedPageEvents)
                {
                    var def = pageEvents.Key;
                    if (def.IsGoal)
                    {
                        var events = new List<GoalEventModel>();
                        var i = 0;
                        foreach (var pageEvent in pageEvents.OrderBy(pe => pe.Timestamp))
                        {
                            events.Add(new GoalEventModel()
                                {
                                    Count = ++i,
                                    Data = pageEvent.Data,
                                    DataCode = pageEvent.DataCode,
                                    DataKey = pageEvent.DataKey,
                                    DateTime = pageEvent.DateTime.ToLocalTime().ToString("g"),
                                    Text = pageEvent.Text
                                });
                        }
                        list.Add(new GoalSectionModel()
                        {
                            Icon = GetImage(def),
                            Name = def.Name,
                            Count = events.Count,
                            GoalEvents = events
                        });
                    }
                }
            }
            return list;
        }
    }
}