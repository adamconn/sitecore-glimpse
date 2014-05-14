namespace Sitecore.Glimpse.Model
{
    /// <summary>
    /// The mvc page model converter.
    /// </summary>
    public class MvcPageModelConverter : PipelineModelConverter<MvcPageModel>
    {
        /// <summary>
        /// Gets the name of the pipeline.
        /// </summary>
        /// <value>
        /// The name of the pipeline.
        /// </value>
        public override string PipelineName
        {
            get { return "glimpse.ConvertMvcPageModel"; }
        }
    }
}