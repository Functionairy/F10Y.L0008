using System;
using System.Runtime.InteropServices;

using F10Y.T0002;


namespace F10Y.L0008
{
    [FunctionsMarker]
    public partial interface IDotnetOperator
    {
        /// <summary>
        /// Gets the dotnet directory path for the current environment.
        /// <para><on-windows-value>On Windows: <inheritdoc cref="IDirectoryPaths.Dotnet_Windows" path="descendant::value"/></on-windows-value></para>
        /// </summary>
        public string Get_DotnetDirectoryPath()
        {
            var operatingSystemPlatform = Instances.OperatingSystemOperator.Get_CurrentOperatingSystemPlatform();

            var output = this.Get_DotnetDirectoryPath(operatingSystemPlatform);
            return output;
        }

        public string Get_DotnetDirectoryPath(OSPlatform operatingSystem)
        {
            var output = Instances.OperatingSystemOperator.SwitchOn_OSPlatform_ByValue(
                // Use the 64-bit location as default.
                Instances.DirectoryPaths.Dotnet_Windows_x64,
                Instances.DirectoryPaths.Dotnet_OSX,
                Instances.DirectoryPaths.Dotnet_Linux);

            return output;
        }

        /// <summary>
        /// The shared frameworks directory, which contains child directories for each shared framework.
        /// </summary>
        /// <remarks>
        /// On Windows: C:\Program Files\dotnet\shared\
        /// </remarks>
        public string Get_SharedFrameworks_DirectoryPath()
        {
            var dotnetDirectoryPath = Instances.DirectoryPaths.dotnet;

            var output = Instances.PathOperator.Get_DirectoryPath(
                dotnetDirectoryPath,
                Instances.DirectoryNames.shared);

            return output;
        }
    }
}
