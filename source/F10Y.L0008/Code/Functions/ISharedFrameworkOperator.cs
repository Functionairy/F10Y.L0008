using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0008
{
    [FunctionsMarker]
    public partial interface ISharedFrameworkOperator
    {
        bool Are_Equal_HandleNull(
            SharedFrameworkDescriptor a,
            SharedFrameworkDescriptor b)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(
                a,
                b,
                this.Are_Equal);

            return output;
        }

        bool Are_Equal(
            SharedFrameworkDescriptor a,
            SharedFrameworkDescriptor b)
        {
            var output = true
                && a.Name == b.Name
                && a.Version == b.Version
                ;

            return output;
        }

        int Compare_Name_ThenVersion(
            SharedFrameworkDescriptor x,
            SharedFrameworkDescriptor y)
        {
            if(Instances.ComparisonOperator.Is_ComparisonDefinitive(
                x, y,
                x => x.Name,
                Instances.StringOperator.Compare,
                out var comparison))
            {
                return comparison;
            }

            if (Instances.ComparisonOperator.Is_ComparisonDefinitive(
                x, y,
                x => x.Version,
                Instances.VersionOperator.Compare,
                out comparison))
            {
                return comparison;
            }

            // Else.
            return comparison;
        }

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

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Compare_Name_ThenVersion(SharedFrameworkDescriptor, SharedFrameworkDescriptor)"/> as the default.
        /// </remarks>
        int Compare(
            SharedFrameworkDescriptor x,
            SharedFrameworkDescriptor y)
            => this.Compare_Name_ThenVersion(x, y);

        N001.SharedFrameworkDescriptor Convert(SharedFrameworkDescriptor sharedFrameworkDescriptor)
            => new()
            {
                Name = sharedFrameworkDescriptor.Name,
                Version = this.Get_SharedFramework_VersionString(sharedFrameworkDescriptor.Version)
            };

        SharedFrameworkDescriptor Convert(N001.SharedFrameworkDescriptor sharedFrameworkDescriptor)
            => new()
            {
                Name = sharedFrameworkDescriptor.Name,
                Version = this.Get_SharedFramework_Version(sharedFrameworkDescriptor.Version)
            };

        public SharedFrameworkDescriptor From(
            string sharedFrameworkName,
            string versionString)
            => this.To_Descriptor(
                sharedFrameworkName,
                versionString);

        public SharedFrameworkDescriptor From(
            string sharedFrameworkName,
            Version version)
            => this.To_Descriptor(
                sharedFrameworkName,
                version);

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

        int Get_HashCode(SharedFrameworkDescriptor sharedFrameworkDescriptor)
        {
            var output = Instances.HashCodeOperator.Combine(
                sharedFrameworkDescriptor.Name,
                sharedFrameworkDescriptor.Version);

            return output;
        }

        string Get_SharedFramework_VersionString(Version version)
            => Instances.VersionOperator.To_String_Major_Minor_Build(version);

        Version Get_SharedFramework_Version(string versionString)
            => Instances.VersionOperator.Parse(versionString);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.For_SharedFrameworks.Example_SharedFramework_DirectoryPath" path="/summary"/>
        /// </remarks>
        public SharedFrameworkDescriptor Get_SharedFrameworkDescriptor_ForSharedFrameworkDirectoryPath(string sharedFramework_DirectoryPath)
        {
            var version_DirectoryName = Instances.PathOperator.Get_DirectoryName(sharedFramework_DirectoryPath);

            var version = this.Get_SharedFramework_Version_FromVersionDirectoryName(version_DirectoryName);

            var sharedFrameworkRoot_DirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForDirectory(sharedFramework_DirectoryPath);

            var sharedFramwork_DirectoryName = Instances.PathOperator.Get_DirectoryName(sharedFrameworkRoot_DirectoryPath);

            var sharedFramework_Name = this.Get_SharedFramework_Name_FromDirectoryName(sharedFramwork_DirectoryName);

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

        public string Get_SharedFramework_Name_FromDirectoryName(string sharedFramwork_DirectoryName)
            => sharedFramwork_DirectoryName;

        public string Get_SharedFramework_DirectoryName_FromName(string sharedFramwork_Name)
            => sharedFramwork_Name;

        public string Get_Version_DirectoryName_FromVersion(Version version)
            => Instances.VersionOperator.To_String(version);

        public Version Get_SharedFramework_Version_FromVersionDirectoryName(string version_DirectoryName)
            => Instances.VersionOperator.Parse(version_DirectoryName);

        IEnumerable<string> To_Lines(SharedFrameworkDescriptor sharedFrameworkDescriptor)
            => Instances.EnumerableOperator.From(
                sharedFrameworkDescriptor.Name,
                Instances.VersionOperator.To_String(sharedFrameworkDescriptor.Version));

        public SharedFrameworkDescriptor To_Descriptor(
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

        public SharedFrameworkDescriptor To_Descriptor(
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
        public SharedFrameworkDescriptor To_Descriptor(string sharedFramework_DirectoryPath)
            => this.Get_SharedFrameworkDescriptor_ForSharedFrameworkDirectoryPath(sharedFramework_DirectoryPath);

        string To_String(
            string sharedFrameworkName,
            string version)
            => $"{sharedFrameworkName}{Instances.TokenSeparators.For_SharedFramework}{version}";

        string To_String(
            string sharedFrameworkName,
            Version version)
        {
            var version_String = this.Get_SharedFramework_VersionString(version);

            var output = this.To_String(
                sharedFrameworkName,
                version_String);

            return output;
        }

        string To_String(SharedFrameworkDescriptor sharedFrameworkDescriptor)
            => this.To_String(
                sharedFrameworkDescriptor.Name,
                sharedFrameworkDescriptor.Version);

        string To_String_ForVersion(Version version)
            => Instances.VersionOperator.To_String(version);
    }
}
