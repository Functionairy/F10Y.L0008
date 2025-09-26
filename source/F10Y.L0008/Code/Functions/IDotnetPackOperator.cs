using System;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0008
{
    [FunctionsMarker]
    public partial interface IDotnetPackOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        Implementations.IDotnetPackOperator _Implementations => Implementations.DotnetPackOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles

        string Get_Pack_DirectoryPath_ForSharedFramework(
            SharedFrameworkDescriptor sharedFramework,
            out string packRef_DirectoryPath,
            out string packVersion_DirectoryPath,
            out string packRoot_DirectoryPath,
            out string packs_DirectoryPath,
            out string dotnet_DirectoryPath)
        {
            dotnet_DirectoryPath = Instances.DirectoryPaths.dotnet;

            packs_DirectoryPath = Instances.PathOperator.Get_DirectoryPath(
                dotnet_DirectoryPath,
                Instances.DirectoryNames.packs);

            var pack_Name = Instances.DotnetPackOperator.Get_PackName_FromSharedFrameworkName(sharedFramework.Name);

            var packRoot_DirectoryName = Instances.DotnetPackOperator.Get_DirectoryName_ForPackName(pack_Name);

            packRoot_DirectoryPath = Instances.PathOperator.Get_DirectoryPath(
                packs_DirectoryPath,
                packRoot_DirectoryName);

            var version_DirectoryName = Instances.DotnetPackOperator.Get_Version_DirectoryName_FromVersion(sharedFramework.Version);

            packVersion_DirectoryPath = Instances.PathOperator.Get_DirectoryPath(
                packRoot_DirectoryPath,
                version_DirectoryName);

            packRef_DirectoryPath = Instances.PathOperator.Get_DirectoryPath(
                packVersion_DirectoryPath,
                Instances.DirectoryNames.@ref);

            var targetFrameworkMoniker = Instances.DotnetPackOperator.Get_TargetFrameworkMoniker_ForPack(
                pack_Name,
                sharedFramework.Version);

            var targetFrameworkMoniker_DirectoryName = Instances.TargetFrameworkMonikerOperator.Get_DirectoryName(targetFrameworkMoniker);

            var pack_DirectoryPath = Instances.PathOperator.Get_DirectoryPath(
                packRef_DirectoryPath,
                targetFrameworkMoniker_DirectoryName);

            return pack_DirectoryPath;
        }

        string Get_Pack_DirectoryPath_ForSharedFramework(
            SharedFrameworkDescriptor sharedFramework)
            => this.Get_Pack_DirectoryPath_ForSharedFramework(
                sharedFramework,
                out _,
                out _,
                out _,
                out _,
                out _);

        string Get_DirectoryName_ForPackName(string pack_Name)
            // The directory name is just the pack name.
            => pack_Name;

        /// <summary>
        /// Gets the dotnet pack name corresponding to a dotnet shared framework name.
        /// </summary>
        string Get_PackName_FromSharedFrameworkName(string sharedFrameworkName)
            => _Implementations.Get_PackName_FromSharedFrameworkName_ByAppendingRefToken(sharedFrameworkName);

        /// <summary>
        /// Gets the dotnet shared framework name corresponding to a dotnet pack name.
        /// </summary>
        string Get_SharedFrameworkName_FromPackName(string packName)
        {
            // Remove the last token ("Ref") from the pack name.
            var output = Instances.TokenOperator.Remove_LastToken(
                packName,
                Instances.TokenSeparators.For_DotnetPackName);

            return output;
        }

        string Get_TargetFrameworkMoniker_ForPack(
            string pack_Name,
            Version version)
            => Instances.TargetFrameworkMonikerOperator.Get_TargetFrameworkMoniker_ForPack(
                pack_Name,
                version);

        string Get_Version_DirectoryName_FromVersion(Version version)
            => Instances.SharedFrameworkOperator.Get_Version_DirectoryName_FromVersion(version);
    }
}
