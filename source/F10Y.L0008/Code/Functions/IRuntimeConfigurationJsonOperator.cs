using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;

using F10Y.T0002;


namespace F10Y.L0008
{
    [FunctionsMarker]
    public partial interface IRuntimeConfigurationJsonOperator
    {
        JsonObject Generate_RuntimeConfiguration_ForSharedFrameworks(
            string targetFrameworkMoniker,
            IEnumerable<N001.SharedFrameworkDescriptor> sharedFrameworks)
        {
            var sharedFrameworks_Converted = sharedFrameworks
                .Select(Instances.SharedFrameworkOperator.Convert)
                ;

            var output = this.Generate_RuntimeConfiguration_ForSharedFrameworks(
                targetFrameworkMoniker,
                sharedFrameworks);

            return output;
        }

        JsonObject Generate_RuntimeConfiguration_ForSharedFrameworks(
            string targetFrameworkMoniker,
            IEnumerable<SharedFrameworkDescriptor> sharedFrameworks)
        {
            var elementNames = Instances.RuntimeConfigurationJsonElementNames;

            var frameworks = sharedFrameworks
                .Select(sharedFramework =>
                {
                    var framework = Instances.JsonOperator.New_Object();

                    framework[elementNames.name] = sharedFramework.Name;
                    framework[elementNames.version] = Instances.SharedFrameworkOperator.To_String_ForVersion(sharedFramework.Version);

                    return framework;
                })
                ;

            var framworksArray = Instances.JsonOperator.New_Array(frameworks);

            var runtimeOptions = Instances.JsonOperator.New_Object();

            // Ensure the target framework moniker is token-less.
            var targetFrameworkMoniker_EnsuredTokenless = Instances.TargetFrameworkMonikerOperator.Ensure_IsTokenless(targetFrameworkMoniker);

            runtimeOptions[elementNames.tfm] = targetFrameworkMoniker_EnsuredTokenless;
            runtimeOptions[elementNames.frameworks] = framworksArray;

            var runtimeConfig = Instances.JsonOperator.New_Object();

            runtimeConfig[elementNames.runtimeOptions] = runtimeOptions;

            return runtimeConfig;
        }

        JsonObject Get_Framework(JsonObject runtimeOptions)
        {
            var output = Instances.JsonOperator.Get_Child_AsObject(
                runtimeOptions,
                Instances.JsonKeys.framework);

            return output;
        }

        public SharedFrameworkDescriptor[] Get_SharedFrameworks_FromRuntimeOptions(JsonObject runtimeOptions)
        {
            var hasFramework = this.Has_Framework(
                runtimeOptions,
                out SharedFrameworkDescriptor framework_OrDefault);


            var hasFrameworks = this.Has_Frameworks(
                runtimeOptions,
                out SharedFrameworkDescriptor[] frameworks_OrDefault);

            var output = Instances.EnumerableOperator.Empty<SharedFrameworkDescriptor>()
                .Append_If(
                    hasFramework,
                    framework_OrDefault)
                .Append_If(
                    hasFrameworks,
                    frameworks_OrDefault)
                .Now();

            return output;
        }

        public JsonObject Get_RuntimeOptions(JsonObject runtimeConfiguration)
        {
            var output = Instances.JsonOperator.Get_Child_AsObject(
                runtimeConfiguration,
                Instances.JsonKeys.runtimeOptions);

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Get_SharedFrameworks_FromRuntimeConfiguration(JsonObject)"/> as the default.
        /// </remarks>
        public SharedFrameworkDescriptor[] Get_SharedFrameworks(JsonObject runtimeConfiguration)
            => this.Get_SharedFrameworks_FromRuntimeConfiguration(runtimeConfiguration);

        public SharedFrameworkDescriptor[] Get_SharedFrameworks_FromRuntimeConfiguration(JsonObject runtimeConfiguration)
        {
            var runtimeOptions = this.Get_RuntimeOptions(runtimeConfiguration);

            var output = this.Get_SharedFrameworks_FromRuntimeOptions(runtimeOptions);
            return output;
        }

        public SharedFrameworkDescriptor Get_SharedFramework(JsonObject framework)
        {
            var sharedFramework_Name = this.Get_SharedFramework_Name(framework);

            var sharedFramework_Version = this.Get_SharedFramework_Version_AsString(framework);

            var sharedFrameworkDescriptor = Instances.SharedFrameworkOperator.To_Descriptor(
                sharedFramework_Name,
                sharedFramework_Version);

            return sharedFrameworkDescriptor;
        }

        public string Get_SharedFramework_Name(JsonObject framework)
        {
            var output = Instances.JsonOperator.Get_Child_Value(
                framework,
                Instances.JsonKeys.name);

            return output;
        }

        public string Get_SharedFramework_Version_AsString(JsonObject framework)
        {
            var output = Instances.JsonOperator.Get_Child_Value(
                framework,
                Instances.JsonKeys.version);

            return output;
        }

        public Version Get_SharedFramework_Version_AsVersion(JsonObject framework)
        {
            var version_String = this.Get_SharedFramework_Version_AsString(framework);

            var output = Instances.VersionOperator.Parse(version_String);
            return output;
        }

        public bool Has_Framework(
            JsonObject runtimeOptions,
            out SharedFrameworkDescriptor framework_OrDefault)
        {
            var output = this.Has_Framework(
                runtimeOptions,
                out JsonObject framework_AsObject_OrDefault);

            framework_OrDefault = Instances.DefaultOperator.Convert(
                framework_AsObject_OrDefault,
                this.Get_SharedFramework);

            return output;
        }

        public bool Has_Framework(
            JsonObject runtimeOptions,
            out JsonObject framework_OrDefault)
            => Instances.JsonOperator.Has_Property_AsObject(
                runtimeOptions,
                Instances.JsonKeys.framework,
                out framework_OrDefault);

        public bool Has_Frameworks(
            JsonObject runtimeOptions,
            out JsonArray frameworks_OrDefault)
            => Instances.JsonOperator.Has_Property_AsArray(
                runtimeOptions,
                Instances.JsonKeys.frameworks,
                out frameworks_OrDefault);

        public bool Has_Frameworks(
            JsonObject runtimeOptions,
            out SharedFrameworkDescriptor[] frameworks_OrDefault)
        {
            var output = this.Has_Frameworks(
                runtimeOptions,
                out JsonArray frameworks_AsObject_OrDefault);

            frameworks_OrDefault = Instances.DefaultOperator.Convert(
                frameworks_AsObject_OrDefault,
                frameworks =>
                {
                    var output = frameworks
                        .Select(x => this.Get_SharedFramework(x.AsObject()))
                        .Now();

                    return output;
                });

            return output;
        }
    }
}
