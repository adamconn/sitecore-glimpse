POST INSTALLATION STEPS
=======================

1. After installing the NuGet package, add the following to web.config in order to prevent Glimpse from running in the Sitecore client:

<glimpse defaultRuntimePolicy="On" endpointBaseUri="~/Glimpse.axd">
 <runtimePolicies>
   <uris>
     <add regex="/sitecore/.*" />
   </uris>
 </runtimePolicies>
</glimpse>

2. Ensure the Glimpse modules and handlers added to the web.config are configured before all Sitecore entries

Questions?
Tweet us at @adc_sitecore or @studert