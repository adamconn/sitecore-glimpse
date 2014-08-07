using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Sitecore.Glimpse.Model;

namespace Sitecore.Glimpse.Pipelines.ConvertContextModel
{
    public class GetUserSection : BaseGetSection<ContextModel, SectionModel>
    {
        public override string SectionName
        {
            get { return "User"; }
        }

        protected override List<SectionModel> GetSectionData(GlimpsePipelineArgs<ContextModel> args)
        {
            var user = args.DataModel.User;
            var list = new List<SectionModel>();
            list.Add(new SectionModel()
            {
                Icon = this.GetImage(user.Profile.Portrait),
                Api = "Sitecore.Context.User",
                Key = "User",
                Value = user.Name
            });
            list.Add(new SectionModel()
            {
                Icon = this.GetImage("Network/16x16/id_cards.png"),
                Api = "Sitecore.Context.User.Roles",
                Key = "Roles",
                Value = String.Join("\n", user.Roles.Select(role => role.Name).ToArray())
            });
            return list;
        }
    }
}