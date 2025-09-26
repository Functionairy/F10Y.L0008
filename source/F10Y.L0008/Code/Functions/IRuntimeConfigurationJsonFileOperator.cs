using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0008
{
    [FunctionsMarker]
    public partial interface IRuntimeConfigurationJsonFileOperator
    {
        async Task Generate_RuntimeConfigurationFile_ForSharedFrameworks(
            string runtimeConfiguration_JsonFilePath,
            string targetFrameworkMoniker,
            IEnumerable<SharedFrameworkDescriptor> sharedFrameworks)
        {
            var libraryRuntimeConfiguration = Instances.RuntimeConfigurationJsonOperator.Generate_RuntimeConfiguration_ForSharedFrameworks(
                targetFrameworkMoniker,
                sharedFrameworks);

            await Instances.JsonOperator.Save_ToFile(
                runtimeConfiguration_JsonFilePath,
                libraryRuntimeConfiguration);
        }

        public async Task<SharedFrameworkDescriptor[]> Get_SharedFrameworks(string runtimeConfiguration_JsonFilePath)
        {
            var runtimeConfiguration = await Instances.JsonOperator.Load_FromFile_AsObject(runtimeConfiguration_JsonFilePath);

            var output = Instances.RuntimeConfigurationJsonOperator.Get_SharedFrameworks(runtimeConfiguration);
            return output;
        }
    }
}
