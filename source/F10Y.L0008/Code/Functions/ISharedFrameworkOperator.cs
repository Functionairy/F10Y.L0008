using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0008
{
    [FunctionsMarker]
    public partial interface ISharedFrameworkOperator :
        T000.ISharedFrameworkOperator
    {
        /// <inheritdoc cref="IDotnetOperator.Get_RuntimeDirectoryPath_ForSharedFramework(SharedFrameworkDescriptor)"/>
        string Get_RuntimeDirectoryPath_ForSharedFramework(SharedFrameworkDescriptor sharedFramework)
            => Instances.DotnetOperator.Get_RuntimeDirectoryPath_ForSharedFramework(sharedFramework);

        int Compare_Version_ThenName(
            SharedFrameworkDescriptor x,
            SharedFrameworkDescriptor y)
        {
            if (Instances.ComparisonOperator.Is_ComparisonDefinitive(
                x, y,
                x => x.Version,
                Instances.VersionOperator.Compare,
                out var comparison))
            {
                return comparison;
            }

            if (Instances.ComparisonOperator.Is_ComparisonDefinitive(
                x, y,
                x => x.Name,
                Instances.StringOperator.Compare,
                out comparison))
            {
                return comparison;
            }

            // Else.
            return comparison;
        }

        int Compare_VersionInverted_ThenName(
            SharedFrameworkDescriptor x,
            SharedFrameworkDescriptor y)
        {
            if (Instances.ComparisonOperator.Is_ComparisonDefinitive(
                x, y,
                x => x.Version,
                Instances.VersionOperator.Compare,
                out var comparison))
            {
                var output = Instances.ComparisonOperator.Invert(comparison);
                return output;
            }

            if (Instances.ComparisonOperator.Is_ComparisonDefinitive(
                x, y,
                x => x.Name,
                Instances.StringOperator.Compare,
                out comparison))
            {
                return comparison;
            }

            // Else.
            return comparison;
        }


        T000.N001.SharedFrameworkDescriptor Convert(SharedFrameworkDescriptor sharedFrameworkDescriptor)
            => new()
            {
                Name = sharedFrameworkDescriptor.Name,
                Version = this.Get_SharedFramework_VersionString(sharedFrameworkDescriptor.Version)
            };

        SharedFrameworkDescriptor Convert(T000.N001.SharedFrameworkDescriptor sharedFrameworkDescriptor)
            => new()
            {
                Name = sharedFrameworkDescriptor.Name,
                Version = this.Get_SharedFramework_Version(sharedFrameworkDescriptor.Version)
            };

        SharedFrameworkDescriptor From(
            string sharedFrameworkName,
            string versionString)
            => this.To_Descriptor(
                sharedFrameworkName,
                versionString);

        SharedFrameworkDescriptor From(
            string sharedFrameworkName,
            Version version)
            => this.To_Descriptor(
                sharedFrameworkName,
                version);

        bool Has_Matching_Latest(
            SharedFrameworkDescriptor targetSharedFramework,
            IEnumerable<SharedFrameworkDescriptor> sharedFrameworks,
            out SharedFrameworkDescriptor matchingSharedFramework_OrDefault)
        {
            var sharedFrameworks_WithName_ByVersion = sharedFrameworks
                .Where(Instances.SharedFrameworkOperations.Is_Named(targetSharedFramework.Name))
                .ToDictionary(sharedFramework => sharedFramework.Version)
                ;

            var any_WithName = sharedFrameworks_WithName_ByVersion.Any();
            if (!any_WithName)
            {
                matchingSharedFramework_OrDefault = default;

                return false;
            }

            var targetVersion = targetSharedFramework.Version;

            var has_MatchingVersion = Instances.VersionOperator.Has_Latest_MatchingMajorVersion(
                targetVersion,
                sharedFrameworks_WithName_ByVersion.Keys,
                out var matchingVersion_OrDefault);

            if (!has_MatchingVersion)
            {
                matchingSharedFramework_OrDefault = default;

                return false;
            }

            // Success.
            matchingSharedFramework_OrDefault = sharedFrameworks_WithName_ByVersion[matchingVersion_OrDefault];

            return true;
        }

        /// <summary>
        /// Matching is when a shared framework with the same name and major version is available.
        /// </summary>
        SharedFrameworkDescriptor Get_Matching_Latest(
            SharedFrameworkDescriptor targetSharedFramework,
            IEnumerable<SharedFrameworkDescriptor> sharedFrameworks)
        {
            var has_Latest_Matching = this.Has_Matching_Latest(
                targetSharedFramework,
                sharedFrameworks,
                out var matchingSharedFramework_OrDefault);

            if (!has_Latest_Matching)
            {
                throw new Exception("No matching shared framework found.");
            }

            return matchingSharedFramework_OrDefault;
        }

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

        For_MethodBasedEqualityComparer.MethodBasedEqualityComparer<SharedFrameworkDescriptor> Get_EqualityComparer()
        {
            var output = Instances.EqualityComparerOperator.Get_MethodBasedEqualityComparer<SharedFrameworkDescriptor>(
                this.Are_Equal,
                this.Get_HashCode);

            return output;
        }

        For_DependencyOrderComparer.DependencyOrderComparer<SharedFrameworkDescriptor> Get_DependencyComparer(
            IDictionary<SharedFrameworkDescriptor, SharedFrameworkDescriptor[]> recursiveDependencies_BySharedFramework)
        {
            var equalityComparer = this.Get_EqualityComparer();

            var output = new For_DependencyOrderComparer.DependencyOrderComparer<SharedFrameworkDescriptor>(
                recursiveDependencies_BySharedFramework,
                equalityComparer);

            return output;
        }

        string[] Get_DocumentationFiles_ForSharedFrameworks_Available(
            IEnumerable<SharedFrameworkDescriptor> sharedFrameworks_Available)
        {
            var packDirectoryPaths = sharedFrameworks_Available
                .Select(Instances.DotnetPackOperator.Get_Pack_DirectoryPath_ForSharedFramework)
                .Now();

            var documentationFilePaths = packDirectoryPaths
                .SelectMany(Instances.DocumentationFileOperator.Get_DocumentationFilePaths)
                .Now();

            return documentationFilePaths;
        }

        Version Get_SharedFramework_Version(string versionString)
            => Instances.VersionOperator.Parse(versionString);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.For_SharedFrameworks.Example_SharedFramework_DirectoryPath" path="/summary"/>
        /// </remarks>
        SharedFrameworkDescriptor Get_SharedFrameworkDescriptor_ForSharedFrameworkDirectoryPath(string sharedFramework_DirectoryPath)
        {
            var version_DirectoryName = Instances.PathOperator.Get_DirectoryName(sharedFramework_DirectoryPath);

            var version = this.Get_SharedFramework_Version_FromVersionDirectoryName(version_DirectoryName);

            var sharedFrameworkRoot_DirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForDirectory(sharedFramework_DirectoryPath);

            var sharedFramwork_DirectoryName = Instances.PathOperator.Get_DirectoryName(sharedFrameworkRoot_DirectoryPath);

            var sharedFramework_Name = this.Get_SharedFramework_Name_FromSharedDirectoryName(sharedFramwork_DirectoryName);

            var output = this.To_Descriptor(
                sharedFramework_Name,
                version);

            return output;
        }

        SharedFrameworkDescriptor Get_SharedFrameworkDescriptor_ForPackDirectoryPath(string pack_DirectoryPath)
        {
            var version_DirectoryName = Instances.PathOperator.Get_DirectoryName(pack_DirectoryPath);

            var version = this.Get_SharedFramework_Version_FromVersionDirectoryName(version_DirectoryName);

            var sharedFrameworkRoot_DirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForDirectory(pack_DirectoryPath);

            var sharedFramwork_DirectoryName = Instances.PathOperator.Get_DirectoryName(sharedFrameworkRoot_DirectoryPath);

            var sharedFramework_Name = this.Get_SharedFramework_Name_FromPackDirectoryName(sharedFramwork_DirectoryName);

            var output = this.To_Descriptor(
                sharedFramework_Name,
                version);

            return output;
        }

        /// <inheritdoc cref="IDotnetPackOperator.Get_PackName_FromSharedFrameworkName(string)"/>
        string Get_PackName_FromSharedFrameworkName(string sharedFrameworkName)
            => Instances.DotnetPackOperator.Get_PackName_FromSharedFrameworkName(sharedFrameworkName);

        /// <inheritdoc cref="IDotnetPackOperator.Get_SharedFrameworkName_FromPackName(string)"/>
        string Get_SharedFrameworkName_FromPackName(string packName)
            => Instances.DotnetPackOperator.Get_SharedFrameworkName_FromPackName(packName);

        string Get_SharedFramework_Name_FromSharedDirectoryName(string sharedFramework_DirectoryName)
            => sharedFramework_DirectoryName;

        string Get_SharedFramework_Name_FromPackDirectoryName(string pack_DirectoryName)
            => Instances.StringOperator.Trim_End(
                pack_DirectoryName,
                Instances.Tokens.dotRef);

        string Get_SharedFramework_DirectoryName_FromName(string sharedFramwork_Name)
            => sharedFramwork_Name;

        string Get_Version_DirectoryName_FromVersion(Version version)
            => Instances.VersionOperator.To_String(version);

        Version Get_SharedFramework_Version_FromVersionDirectoryName(string version_DirectoryName)
            => Instances.VersionOperator.Parse(version_DirectoryName);

        IEnumerable<string> To_Lines(SharedFrameworkDescriptor sharedFrameworkDescriptor)
            => Instances.EnumerableOperator.From(
                sharedFrameworkDescriptor.Name,
                Instances.VersionOperator.To_String(sharedFrameworkDescriptor.Version));

        SharedFrameworkDescriptor To_Descriptor(
            string sharedFrameworkName,
            Version version)
        {
            var output = new SharedFrameworkDescriptor
            {
                Name = sharedFrameworkName,
                Version = version,
            };

            return output;
        }

        SharedFrameworkDescriptor To_Descriptor(
            string sharedFrameworkName,
            string versionString)
        {
            var version = Instances.VersionOperator.Parse(versionString);

            var output = this.To_Descriptor(
                sharedFrameworkName,
                version);

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_SharedFrameworkDescriptor_ForSharedFrameworkDirectoryPath(string)"/>
        /// </summary>
        SharedFrameworkDescriptor To_Descriptor(string sharedFramework_DirectoryPath)
            => this.Get_SharedFrameworkDescriptor_ForSharedFrameworkDirectoryPath(sharedFramework_DirectoryPath);

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_SharedFrameworkDescriptor_ForSharedFrameworkDirectoryPath(string)"/>
        /// </summary>
        SharedFrameworkDescriptor To_Descriptor_FromRuntimeSharedFrameworkDirectoryPath(string sharedFramework_DirectoryPath)
            => this.Get_SharedFrameworkDescriptor_ForSharedFrameworkDirectoryPath(sharedFramework_DirectoryPath);

        SharedFrameworkDescriptor To_Descriptor_FromPackDirectoryPath(string pack_DirectoryPath)
            => this.Get_SharedFrameworkDescriptor_ForPackDirectoryPath(pack_DirectoryPath);

        string To_String_ForVersion(Version version)
            => Instances.VersionOperator.To_String(version);
    }
}
