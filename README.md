Sitecore Plugin for Glimpse is a... um... plugin for Glimpse that displays Sitecore information. It allows you to control the information that is displayed, along with how that information is displayed.

### Installation Instructions
1. Install the Sitecore Glimpse NuGet package into your website project
	* [Sitecore 6](https://www.nuget.org/packages/Glimpse.Sitecore6/)
	* [Sitecore 7](https://www.nuget.org/packages/Glimpse.Sitecore7/)
2. Add the following to web.config in order to prevent Glimpse from running in the Sitecore client:

	    <glimpse defaultRuntimePolicy="On" endpointBaseUri="~/Glimpse.axd">
	    	<runtimePolicies>
	    		<uris>
	    			<add regex="/sitecore/.*" />
	    		</uris>
	    	</runtimePolicies>
	    </glimpse>

3. Ensure the Glimpse modules and handlers added to the web.config are configured before all Sitecore entries
4. Open your browser

### Tutorials and Other Information
Read me at [http://www.sitecore.net/Community/Technical-Blogs/Getting-to-Know-Sitecore.aspx](http://www.sitecore.net/Community/Technical-Blogs/Getting-to-Know-Sitecore.aspx)

### Questions? 
Tweet us at [@adc_sitecore](https://twitter.com/@adc_sitecore) or [@studert](https://twitter.com/@studert)