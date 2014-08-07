POST INSTALLATION STEPS
=======================

After installing the NuGet package, add the following to web.config in order to prevent Glimpse from running in the Sitecore client:

<glimpse defaultRuntimePolicy="On" endpointBaseUri="~/Glimpse.axd">
 <runtimePolicies>
   <uris>
     <add regex="/sitecore/.*" />
   </uris>
 </runtimePolicies>
</glimpse>

Questions?
Tweet us at @adc_sitecore or @studert