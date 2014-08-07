namespace Sitecore.Glimpse.Pipelines.GetMvcPageTabData
{
    using Sitecore.Diagnostics;
    using Sitecore.Glimpse.Model;
    using Sitecore.Glimpse.Pipelines;

    /// <summary>
    /// The mvc page model getter.
    /// </summary>
    public class GetMvcPageModel
    {
        /// <summary>
        /// Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void Process(GlimpsePipelineArgs<MvcPageModel> args)
        {
            Assert.ArgumentNotNull(args, "args");
            args.TabData = new MvcPageModel();
        }
    }
}