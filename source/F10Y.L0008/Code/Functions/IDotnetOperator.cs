using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using F10Y.T0002;

using Documentation_For_SharedFrameworks = F10Y.L0008.Documentation.For_SharedFrameworks;


namespace F10Y.L0008
{
    [FunctionsMarker]
    public partial interface IDotnetOperator
    {
        string Get_RuntimeConfiguration_JsonFileName_ForAssembly(string assemblyName)
        {
            var output = Instances.StringOperator.Format(
                Instances.TemplateStrings.For_runtimeconfig_json,
                assemblyName);

            return output;
        }

        string Get_RuntimeConfiguration_JsonFileName_ForSharedFramework(string sharedFramework_Name)
            // Re-use the assembly template, assuming the shared framework name is the assembly name.
            => this.Get_RuntimeConfiguration_JsonFileName_ForAssembly(sharedFramework_Name);

        /// <summary>
        /// Gets the runtime directory path for a shared framework.
        /// <para>
        /// Example: <inheritdoc cref="Documentation_For_SharedFrameworks.Example_SharedFramework_DirectoryPath" path="descendant::value"/>
        /// </para>
        /// </summary>
        string Get_RuntimeDirectoryPath_ForSharedFramework(SharedFrameworkDescriptor sharedFramework)
        {
            var sharedFramework_DirectoryName = Instances.SharedFrameworkOperator.Get_SharedFramework_DirectoryName_FromName(sharedFramework.Name);
            var version_DiretoryName = Instances.SharedFrameworkOperator.Get_Version_DirectoryName_FromVersion(sharedFramework.Version);

            var output = Instances.PathOperator.Combine(
                Instances.DirectoryPaths.dotnet_shared,
                sharedFramework_DirectoryName,
                version_DiretoryName);

            return output;
        }

        /// <inheritdoc cref="Get_RuntimeDirectoryPath_ForSharedFramework(L0008.T000.SharedFrameworkDescriptor)"/>
        string Get_DirectoryPath_ForSharedFramework(SharedFrameworkDescriptor sharedFramework)
            => this.Get_RuntimeDirectoryPath_ForSharedFramework(sharedFramework);

        string Get_RuntimeConfiguration_JsonFilePath_ForSharedFramework(SharedFrameworkDescriptor sharedFramework)
        {
            var sharedFramework_DirectoryPath = this.Get_DirectoryPath_ForSharedFramework(sharedFramework);

            var runtimeConfig_JsonFileName = this.Get_RuntimeConfiguration_JsonFileName_ForSharedFramework(sharedFramework.Name);

            var output = Instances.PathOperator.Get_FilePath(
                sharedFramework_DirectoryPath,
                runtimeConfig_JsonFileName);

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Note: shared framework must be available on the local machine.
        /// </remarks>
        async Task<SharedFrameworkDescriptor[]> Get_DirectDepenencies_OfSharedFramework(SharedFrameworkDescriptor sharedFramework)
        {
            var runtimeConfig_JsonFilePath = this.Get_RuntimeConfiguration_JsonFilePath_ForSharedFramework(sharedFramework);

            var output = await Instances.RuntimeConfigurationJsonFileOperator.Get_SharedFrameworks(runtimeConfig_JsonFilePath);
            return output;
        }

        async Task<(
            Dictionary<SharedFrameworkDescriptor, SharedFrameworkDescriptor[]> directDependencies,
            Dictionary<SharedFrameworkDescriptor, SharedFrameworkDescriptor[]> recursiveDependencies_Exclusive
            )>
            Get_RecursiveAndDirectDependencies_OfSharedFrameworks(IEnumerable<SharedFrameworkDescriptor> sharedFrameworks)
        {
            var sharedFrameworks_Encountered = Instances.HashSetOperator.New(sharedFrameworks);

            var sharedFrameworks_Todo = Instances.QueueOperator.New(sharedFrameworks);

            var directDependencies = Instances.DictionaryOperator.New<SharedFrameworkDescriptor, SharedFrameworkDescriptor[]>();

            while (sharedFrameworks_Todo.Any())
            {
                var sharedFramework_Current = sharedFrameworks_Todo.Dequeue();

                var directDependencies_OfCurrent = await this.Get_DirectDepenencies_OfSharedFramework(sharedFramework_Current);

                directDependencies.Add(
                    sharedFramework_Current,
                    directDependencies_OfCurrent);

                sharedFrameworks_Encountered.Add(sharedFramework_Current);

                foreach (var directDependency in directDependencies_OfCurrent)
                {
                    var encountered = sharedFrameworks_Encountered.Contains(directDependency);
                    if (!encountered)
                    {
                        sharedFrameworks_Todo.Enqueue(directDependency);
                    }
                }
            }

            var recursiveDependencies = Instances.MappingsOperator.Get_RecursiveMappings_Exclusive(
                directDependencies,
                out _);

            return (directDependencies, recursiveDependencies);
        }

        async Task<Dictionary<SharedFrameworkDescriptor, SharedFrameworkDescriptor[]>> Get_RecursiveDependencies_Exclusive_BySharedFramework_OfFrameworks(IEnumerable<SharedFrameworkDescriptor> sharedFrameworks)
        {
            var (_, recursiveDependencies_Exclusive) = await this.Get_RecursiveAndDirectDependencies_OfSharedFrameworks(sharedFrameworks);

            return recursiveDependencies_Exclusive;
        }

        Task<Dictionary<SharedFrameworkDescriptor, SharedFrameworkDescriptor[]>> Get_RecursiveDependencies_Exclusive_BySharedFramework_OfFrameworks(params SharedFrameworkDescriptor[] sharedFrameworks)
            => this.Get_RecursiveDependencies_Exclusive_BySharedFramework_OfFrameworks(sharedFrameworks.AsEnumerable());

        SharedFrameworkDescriptor[] Get_AvailableSharedFrameworks_MatchingRequired(
            IEnumerable<SharedFrameworkDescriptor> sharedFrameworks_Required,
            IList<SharedFrameworkDescriptor> sharedFrameworks_Available)
        {
            var output = sharedFrameworks_Required
                .Select(sharedFramework => Instances.SharedFrameworkOperator.Get_Matching_Latest(
                    sharedFramework,
                    sharedFrameworks_Available)
                )
                .Now();

            return output;
        }

        /// <inheritdoc cref="L0008.IDotnetOperator.Enumerate_SharedFrameworkDirectoryPaths_FromSharedDirectory(string)"/>>
        IEnumerable<string> Enumerate_SharedFrameworkDirectoryPaths_FromSharedDirectory()
            => this.Enumerate_SharedFrameworkDirectoryPaths_FromSharedDirectory(Instances.DirectoryPaths.dotnet_shared);

        /// <inheritdoc cref="L0008.IDotnetOperator.Enumerate_SharedFrameworkDirectoryPaths_FromSharedDirectory(string)" path="/summary"/>
        /// <remarks>
        /// Chooses <see cref="Enumerate_SharedFrameworkDirectoryPaths_FromSharedDirectory()"/> as the default.
        /// <para>
        /// <inheritdoc cref="L0008.IDotnetOperator.Enumerate_SharedFrameworkDirectoryPaths_FromSharedDirectory(string)" path="/remarks"/>
        /// </para>
        /// </remarks>
        IEnumerable<string> Enumerate_SharedFrameworkDirectoryPaths()
            => this.Enumerate_SharedFrameworkDirectoryPaths_FromSharedDirectory();

        IEnumerable<(SharedFrameworkDescriptor descriptor, string directoryPath)> Enumerate_SharedFrameworks_AndDirectoryPaths()
            => this.Enumerate_SharedFrameworkDirectoryPaths()
                .Select(this.Get_SharedFrameworkDescriptor_AndDirectoryPath)
                ;

        (SharedFrameworkDescriptor descriptor, string directoryPath) Get_SharedFrameworkDescriptor_AndDirectoryPath(string sharedFramework_DirectoryPath)
            => (Instances.SharedFrameworkOperator.To_Descriptor(sharedFramework_DirectoryPath), sharedFramework_DirectoryPath);

        /// <summary>
        /// Enumerate the individual shared framework directory paths (shared framework name + version) for a given shared framework root directory (just the shared framework name).
        /// </summary>
        /// <remarks>
        /// <para><inheritdoc cref="Documentation.For_SharedFrameworks.Example_SharedFrameworkRoot_DirectoryPath" path="/summary"/></para>
        /// <para><inheritdoc cref="Documentation.For_SharedFrameworks.Example_SharedFramework_DirectoryPath" path="/summary"/></para>
        /// </remarks>
        IEnumerable<string> Enumerate_SharedFrameworkDirectoryPaths_FromSharedFrameworkRootDirectoryPath(string sharedFrameworkRoot_DirectoryPath)
            => Instances.FileSystemOperator.Enumerate_ChildDirectoryPaths(sharedFrameworkRoot_DirectoryPath);

        IEnumerable<string> Enumerate_SharedFrameworkDirectoryPaths_FromSharedDirectoryPath(
            string dotnet_shared_DirectoryPath,
            string sharedFramework_Name)
        {
            var sharedFrameworkRoot_Directorypath = this.Get_SharedFramework_RootDirectoryPath(
                dotnet_shared_DirectoryPath,
                sharedFramework_Name);

            var output = this.Enumerate_SharedFrameworkDirectoryPaths_FromSharedFrameworkRootDirectoryPath(sharedFrameworkRoot_Directorypath);
            return output;
        }

        /// <summary>
        /// Enumerate all shared framework directory paths (shared framework name + version) on the local machine in the dotnet shared.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.For_SharedFrameworks.Example_SharedFramework_DirectoryPath" path="/summary"/>
        /// </remarks>
        IEnumerable<string> Enumerate_SharedFrameworkDirectoryPaths_FromSharedDirectory(string dotnet_shared_DirectoryPath)
            => Instances.FileSystemOperator.Enumerate_GrandchildDirectoryPaths(dotnet_shared_DirectoryPath);

        /// <summary>
        /// Enumerate all shared framework directory paths (shared framework name + version) on the local machine in the dotnet packs directory.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.For_SharedFrameworks.Example_SharedFramework_DirectoryPath" path="/summary"/>
        /// </remarks>
        IEnumerable<string> Enumerate_SharedFrameworkDirectoryPaths_FromPacksDirectoryPath(string dotnet_packs_DirectoryPath)
            => Instances.FileSystemOperator.Enumerate_GrandchildDirectoryPaths(dotnet_packs_DirectoryPath);

        /// <summary>
        /// Gets the dotnet directory path for the current environment.
        /// <para><on-windows-value>On Windows: <inheritdoc cref="IDirectoryPaths.Dotnet_Windows" path="descendant::value"/></on-windows-value></para>
        /// </summary>
        string Get_DotnetDirectoryPath()
        {
            var operatingSystemPlatform = Instances.OperatingSystemOperator.Get_CurrentOperatingSystemPlatform();

            var output = this.Get_DotnetDirectoryPath(operatingSystemPlatform);
            return output;
        }

        string Get_DotnetDirectoryPath(OSPlatform operatingSystem)
        {
            var output = Instances.OperatingSystemOperator.SwitchOn_OSPlatform_ByValue(
                // Use the 64-bit location as default.
                Instances.DirectoryPaths.Dotnet_Windows_x64,
                Instances.DirectoryPaths.Dotnet_OSX,
                Instances.DirectoryPaths.Dotnet_Linux);

            return output;
        }

        SharedFrameworkDescriptor[] Get_SharedFrameworks_Available()
            => this.Enumerate_SharedFrameworks_AndDirectoryPaths()
                .Select(tuple => tuple.descriptor)
                .Now();

        /// <summary>
        /// The shared frameworks directory, which contains child directories for each shared framework.
        /// </summary>
        /// <remarks>
        /// On Windows: C:\Program Files\dotnet\shared\
        /// </remarks>
        string Get_SharedFrameworks_DirectoryPath()
        {
            var dotnetDirectoryPath = Instances.DirectoryPaths.dotnet;

            var output = Instances.PathOperator.Get_DirectoryPath(
                dotnetDirectoryPath,
                Instances.DirectoryNames.shared);

            return output;
        }

        /// <summary>
        /// Gets the root directory for a shared framework.
        /// </summary>
        /// <remarks>
        /// <para><inheritdoc cref="Documentation.For_SharedFrameworks.Example_SharedFrameworkRoot_DirectoryPath" path="/summary"/></para>
        /// <para><inheritdoc cref="Documentation.For_SharedFrameworks.Example_SharedFramework_DirectoryPath" path="/summary"/></para>
        /// </remarks>
        string Get_SharedFramework_RootDirectoryPath(
            string dotnet_Shared_DirectoryPath,
            string sharedFramework_Name)
        {
            var sharedFramework_DirectoryName = Instances.SharedFrameworkOperator.Get_SharedFramework_DirectoryName_FromName(sharedFramework_Name);

            var output = Instances.PathOperator.Get_DirectoryPath(
                dotnet_Shared_DirectoryPath,
                sharedFramework_DirectoryName);

            return output;
        }

        /// <summary>
        /// The shared frameworks directory, which contains child directories for each shared framework.
        /// </summary>
        /// <remarks>
        /// On Windows: C:\Program Files\dotnet\packs\
        /// </remarks>
        string Get_Packs_DirectoryPath()
        {
            var dotnetDirectoryPath = Instances.DirectoryPaths.dotnet;

            var output = Instances.PathOperator.Get_DirectoryPath(
                dotnetDirectoryPath,
                Instances.DirectoryNames.packs);

            return output;
        }
    }
}
