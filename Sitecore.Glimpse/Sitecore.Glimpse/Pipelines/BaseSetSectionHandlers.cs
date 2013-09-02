using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Tab.Assist;
using Sitecore.Diagnostics;

namespace Sitecore.Glimpse.Pipelines
{
    public abstract class BaseSetSectionHandlers<TDataModel>
    {
        protected BaseSetSectionHandlers()
        {
            _sectionNames = new List<string>();
        }
        public virtual void Process(GlimpsePipelineArgs<TDataModel> args)
        {
            Assert.ArgumentNotNull(args, "args");
            var handlers = args.SectionHandlers;
            if (handlers == null)
            {
                handlers = new Dictionary<string, Action<TabLayoutRow>>();
            }
            foreach (var name in _sectionNames)
            {
                handlers.Add(name, GetRowHandler(name));
            }
            args.SectionHandlers = handlers;
        }
        protected virtual Action<TabLayoutRow> GetRowHandler(string sectionName)
        {
            return DefaultRowHandler;
        }

        private void DefaultRowHandler(TabLayoutRow tabLayoutRow)
        {
            tabLayoutRow.Cell("!{{icon}}!").WithTitle("!&nbsp;!").WidthInPixels(20);
            tabLayoutRow.Cell("key").WithTitle("Key").AsKey().AlignRight().WidthInPixels(100);
            tabLayoutRow.Cell("value").WithTitle("Value").WidthInPixels(250);
            tabLayoutRow.Cell("api").WithTitle("API").AsCode(CodeType.Csharp);
        }

        private List<string> _sectionNames;
        protected void AddSectionName(string name)
        {
            _sectionNames.Add(name);
        }
    }
}