namespace Sitecore.Glimpse.Tabs
{
    using Sitecore.Glimpse.Model;

    /// <summary>
    /// The sitecore mvc page tab class.
    /// </summary>
    public class SitecoreMvcPageTab : PipelineTab<MvcPageModel>
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
        {
            get
            {
                return "Sitecore MVC Page";
            }
        }

        /// <summary>
        /// Gets the name of the data pipeline.
        /// </summary>
        /// <value>
        /// The name of the data pipeline.
        /// </value>
        public override string DataPipelineName
        {
            get
            {
                return "glimpse.GetMvcPageTabData";
            }
        }

        /// <summary>
        /// Gets the name of the layout pipeline.
        /// </summary>
        /// <value>
        /// The name of the layout pipeline.
        /// </value>
        public override string LayoutPipelineName
        {
            get
            {
                return "glimpse.InitMvcPageTabLayout";
            }
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public override string Key
        {
            get
            {
                return "glimpse_sitecore_mvc_page";
            }
        }
    }
}