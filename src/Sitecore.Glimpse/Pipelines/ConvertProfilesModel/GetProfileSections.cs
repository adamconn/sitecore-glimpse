using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Glimpse.Core.Tab.Assist;
using Sitecore.Analytics.Data.DataAccess.DataSets;
using Sitecore.Analytics.Data.Items;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertProfilesModel
{
    public class GetProfileSections : BaseGetSection<ProfilesModel, RawOutputSectionModel>
    {
        public override string SectionName
        {
            get { return null; }
        }
        protected override void AddSectionDataToTab(List<RawOutputSectionModel> sectionModels, TabObject tab)
        {
            if (sectionModels != null && sectionModels.Count > 0)
            {
                foreach (var model in sectionModels)
                {
                    tab.AddRow().Key(model.SectionHeader).Value(model.SectionBody);
                }
            }
        }
        protected virtual string GetProfileLabel(VisitorDataSet.ProfilesRow profile, Database database)
        {
            var profileItem = GetProfileItem(profile, database);
            var profileIcon = GetImage(profileItem);
            var label = string.Format("<span style='margin-right:10px;'>{0}</span><span style='vertical-align:top;'>{1}</span>", profileIcon, profileItem.Name);
            return label;
        }
        protected virtual string GetMatchingPatternLabel(VisitorDataSet.ProfilesRow profile, Database database)
        {
            var builder = new StringBuilder();
            var patternItem = (PatternCardItem)GetPatternItem(profile, database);
            if (patternItem != null)
            {
                builder.Append("<div style='padding-bottom:5px;'>");
                //builder.AppendFormat("<span style='margin-left:10px; margin-right:10px;'>{0}</span>", GetImage(patternItem.Image.MediaItem));
                builder.AppendFormat("<span style='margin-left:10px; margin-right:10px;'>{0}</span>", GetImage(patternItem.Image));
                builder.AppendFormat("<span style='margin-right:10px; vertical-align:top;'>{0}:</span>", Translate.Text("Matches the pattern"));
                builder.AppendFormat("<span style='vertical-align:top'>{0}</span>", patternItem.Name);
                builder.Append("</div>");
            }
            return builder.ToString();
        }
        protected virtual List<string> GetProfileKeyLabels(VisitorDataSet.ProfilesRow profile, Database database)
        {
            var list = new List<string>();
            var keys = GetPatternValues(profile);
            var profileItem = GetProfileItem(profile, database);
            foreach (var pair in keys)
            {
                var keyItem = profileItem.Children[pair.Key];
                if (keyItem != null)
                {
                    var builder = new StringBuilder();
                    builder.Append("<div style='padding-bottom:5px;'>");
                    builder.AppendFormat("<span style='margin-left:10px; margin-right:10px;'>{0}</span>", GetImage(keyItem));
                    builder.AppendFormat("<span style='margin-right:10px; vertical-align:top;'>{0}:</span>", keyItem.Name);
                    builder.AppendFormat("<span style='vertical-align:top'>{0}</span>", pair.Value);
                    builder.Append("</div>");
                    list.Add(builder.ToString());
                }
            }
            return list;
        }
        protected override List<RawOutputSectionModel> GetSectionData(GlimpsePipelineArgs<ProfilesModel> args)
        {
            var model = args.DataModel;
            var list = new List<RawOutputSectionModel>();
            foreach (var profile in model.Profiles.OrderBy(row => row.ProfileName))
            {
                var rows = new List<string>();
                rows.Add(GetMatchingPatternLabel(profile, model.Database));
                rows.AddRange(GetProfileKeyLabels(profile, model.Database));
                rows.Remove(string.Empty);
                var sectionModel = new RawOutputSectionModel()
                    {
                        SectionHeader = GetProfileLabel(profile, model.Database),
                        SectionBody = rows.Aggregate((s1, s2) => s1 + s2)
                    };
                list.Add(sectionModel);
            }
            if (list.Count == 0)
            {
                var sectionModel = new RawOutputSectionModel()
                    {
                        SectionHeader = Translate.Text("No profile information"),
                        SectionBody = Translate.Text("The visitor has not visited any pages that result in profile values being set.")
                    };
                list.Add(sectionModel);
            }
            return list;
        }
        protected virtual Item GetProfileItem(VisitorDataSet.ProfilesRow profile, Database database)
        {
            var analyticsRoot = database.GetItem(Sitecore.ItemIDs.Analytics.Profiles);
            var profileItem = analyticsRoot.Axes.GetDescendant(profile.ProfileName);
            return profileItem;
        }
        protected virtual Item GetPatternItem(VisitorDataSet.ProfilesRow profile, Database database)
        {
            var patternId = new ID(profile.PatternId);
            if (patternId.IsNull)
            {
                return null;
            }
            var patternItem = database.GetItem(patternId);
            return patternItem;
        }
        protected virtual Dictionary<string, int> GetPatternValues(VisitorDataSet.ProfilesRow profile)
        {
            // The following is an example of a value from the PatternValues property:
            //     count=1;total=10;analytics=0.5;copywriting=3.5;personalization and testing=2.5;technology=2.5;workflow and publishing=1
            var values = new Dictionary<string, int>();
            var splitValues = profile.PatternValues.Split(';');
            for (var i = 2; i < splitValues.Length; i++)
            {
                var value = splitValues[i].Split('=');
                var keyValue = 0;
                int.TryParse(value[1], out keyValue);
                values.Add(value[0], keyValue);
            }
            return values;
        }

    }
}