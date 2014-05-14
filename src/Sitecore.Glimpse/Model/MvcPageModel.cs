namespace Sitecore.Glimpse.Model
{
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// The mvc page model.
    /// </summary>
    public class MvcPageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MvcPageModel"/> class.
        /// </summary>
        public MvcPageModel()
        {
            this.Layout = Context.Page.FilePath;
            this.Page = PageContext.Current;
        }

        /// <summary>
        /// Gets or sets the layout.
        /// </summary>
        /// <value>
        /// The layout.
        /// </value>
        public string Layout { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public PageContext Page { get; set; }
    }
}