using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Glimpse.Model
{
    public class ProfilesModelConverter : PipelineModelConverter<ProfilesModel>
    {
        public override string PipelineName
        {
            get { return "glimpse.ConvertProfilesModel"; }
        }
    }
}