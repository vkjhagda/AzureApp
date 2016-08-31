<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="AzureCloudServiceImageProcessing" generation="1" functional="0" release="0" Id="a776abce-2fcc-4192-8c44-14001107411f" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="AzureCloudServiceImageProcessingGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="ImageReSizeWebRole:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/LB:ImageReSizeWebRole:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="ImageReSizeWebRole:Images20By20" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWebRole:Images20By20" />
          </maps>
        </aCS>
        <aCS name="ImageReSizeWebRole:Images40by40" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWebRole:Images40by40" />
          </maps>
        </aCS>
        <aCS name="ImageReSizeWebRole:LoginTable" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWebRole:LoginTable" />
          </maps>
        </aCS>
        <aCS name="ImageReSizeWebRole:OriginalImages" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWebRole:OriginalImages" />
          </maps>
        </aCS>
        <aCS name="ImageReSizeWebRole:QueueName" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWebRole:QueueName" />
          </maps>
        </aCS>
        <aCS name="ImageReSizeWebRole:StorageConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWebRole:StorageConnectionString" />
          </maps>
        </aCS>
        <aCS name="ImageReSizeWebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWebRoleInstances" />
          </maps>
        </aCS>
        <aCS name="ImageReSizeWorkerRole:Images20by20" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWorkerRole:Images20by20" />
          </maps>
        </aCS>
        <aCS name="ImageReSizeWorkerRole:Images40by40" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWorkerRole:Images40by40" />
          </maps>
        </aCS>
        <aCS name="ImageReSizeWorkerRole:OriginalImages" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWorkerRole:OriginalImages" />
          </maps>
        </aCS>
        <aCS name="ImageReSizeWorkerRole:QueueName" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWorkerRole:QueueName" />
          </maps>
        </aCS>
        <aCS name="ImageReSizeWorkerRole:StorageConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWorkerRole:StorageConnectionString" />
          </maps>
        </aCS>
        <aCS name="ImageReSizeWorkerRole:WorkerRoleLogTableName" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWorkerRole:WorkerRoleLogTableName" />
          </maps>
        </aCS>
        <aCS name="ImageReSizeWorkerRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/MapImageReSizeWorkerRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:ImageReSizeWebRole:Endpoint1">
          <toPorts>
            <inPortMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWebRole/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapImageReSizeWebRole:Images20By20" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWebRole/Images20By20" />
          </setting>
        </map>
        <map name="MapImageReSizeWebRole:Images40by40" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWebRole/Images40by40" />
          </setting>
        </map>
        <map name="MapImageReSizeWebRole:LoginTable" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWebRole/LoginTable" />
          </setting>
        </map>
        <map name="MapImageReSizeWebRole:OriginalImages" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWebRole/OriginalImages" />
          </setting>
        </map>
        <map name="MapImageReSizeWebRole:QueueName" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWebRole/QueueName" />
          </setting>
        </map>
        <map name="MapImageReSizeWebRole:StorageConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWebRole/StorageConnectionString" />
          </setting>
        </map>
        <map name="MapImageReSizeWebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWebRoleInstances" />
          </setting>
        </map>
        <map name="MapImageReSizeWorkerRole:Images20by20" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWorkerRole/Images20by20" />
          </setting>
        </map>
        <map name="MapImageReSizeWorkerRole:Images40by40" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWorkerRole/Images40by40" />
          </setting>
        </map>
        <map name="MapImageReSizeWorkerRole:OriginalImages" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWorkerRole/OriginalImages" />
          </setting>
        </map>
        <map name="MapImageReSizeWorkerRole:QueueName" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWorkerRole/QueueName" />
          </setting>
        </map>
        <map name="MapImageReSizeWorkerRole:StorageConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWorkerRole/StorageConnectionString" />
          </setting>
        </map>
        <map name="MapImageReSizeWorkerRole:WorkerRoleLogTableName" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWorkerRole/WorkerRoleLogTableName" />
          </setting>
        </map>
        <map name="MapImageReSizeWorkerRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWorkerRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="ImageReSizeWebRole" generation="1" functional="0" release="0" software="\\RCV02\Users\Public\AzureSampleProject\AzureCloudServiceImageProcessing\AzureCloudServiceImageProcessing\csx\Debug\roles\ImageReSizeWebRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Images20By20" defaultValue="" />
              <aCS name="Images40by40" defaultValue="" />
              <aCS name="LoginTable" defaultValue="" />
              <aCS name="OriginalImages" defaultValue="" />
              <aCS name="QueueName" defaultValue="" />
              <aCS name="StorageConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;ImageReSizeWebRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;ImageReSizeWebRole&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;ImageReSizeWorkerRole&quot; /&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWebRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWebRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWebRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
        <groupHascomponents>
          <role name="ImageReSizeWorkerRole" generation="1" functional="0" release="0" software="\\RCV02\Users\Public\AzureSampleProject\AzureCloudServiceImageProcessing\AzureCloudServiceImageProcessing\csx\Debug\roles\ImageReSizeWorkerRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="-1" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <settings>
              <aCS name="Images20by20" defaultValue="" />
              <aCS name="Images40by40" defaultValue="" />
              <aCS name="OriginalImages" defaultValue="" />
              <aCS name="QueueName" defaultValue="" />
              <aCS name="StorageConnectionString" defaultValue="" />
              <aCS name="WorkerRoleLogTableName" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;ImageReSizeWorkerRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;ImageReSizeWebRole&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;ImageReSizeWorkerRole&quot; /&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWorkerRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWorkerRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWorkerRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="ImageReSizeWebRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyUpdateDomain name="ImageReSizeWorkerRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="ImageReSizeWebRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyFaultDomain name="ImageReSizeWorkerRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="ImageReSizeWebRoleInstances" defaultPolicy="[1,1,1]" />
        <sCSPolicyID name="ImageReSizeWorkerRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="6574227c-08bb-4a05-bba7-55967110878d" ref="Microsoft.RedDog.Contract\ServiceContract\AzureCloudServiceImageProcessingContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="6011d890-5111-4264-ac4c-881eaa84ef3f" ref="Microsoft.RedDog.Contract\Interface\ImageReSizeWebRole:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/AzureCloudServiceImageProcessing/AzureCloudServiceImageProcessingGroup/ImageReSizeWebRole:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>