using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertContextModel
{
    public class GetProfileSection : BaseGetSection<ContextModel, SectionModel>
    {
        public override string SectionName
        {
            get { return "Profile"; }
        }

        protected override List<SectionModel> GetSectionData(GlimpsePipelineArgs<ContextModel> args)
        {
            var defaultIcon = this.GetImage("People/16x16/user1_view.png");
            var profile = args.DataModel.User.Profile;
            var list = new List<SectionModel>();

            var names = profile.GetCustomPropertyNames();
            foreach (var name in names)
            {
                list.Add(new SectionModel()
                {
                    Icon = defaultIcon,
                    Api = string.Format("Sitecore.Context.User.Profile.GetCustomProperty(\"{0}\")", name),
                    Key = name,
                    Value = profile.GetCustomProperty(name)
                });
            }
            return list;
        }
    }
}