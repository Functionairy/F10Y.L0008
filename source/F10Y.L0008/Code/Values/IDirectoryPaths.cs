using System;

using F10Y.T0003;
using F10Y.T0011;


namespace F10Y.L0008
{
    [ValuesMarker]
    public partial interface IDirectoryPaths
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        Raw.IDirectoryPaths _Raw => Raw.DirectoryPaths.Instance;

#pragma warning restore IDE1006 // Naming Styles


#pragma warning disable IDE1006 // Naming Styles

        /// <inheritdoc cref="IDotnetOperator.Get_DotnetDirectoryPath()"/>
        string dotnet => Instances.DotnetOperator.Get_DotnetDirectoryPath();

        /// <inheritdoc cref="IDotnetOperator.Get_SharedFrameworks_DirectoryPath"/>
        string dotnet_shared => Instances.DotnetOperator.Get_SharedFrameworks_DirectoryPath();

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Use the x64 (Program Files) dotnet location as the Windows default.
        /// <para><inheritdoc cref="Dotnet_Windows_x64" path="descendant::value"/></para>
        /// </summary>
        string Dotnet_Windows => this.Dotnet_Windows_x64;

        /// <summary>
        /// The 64-bit (x64) dotnet location on Windows.
        /// <para><inheritdoc cref="Raw.IDirectoryPaths.C_ProgramFiles_dotnet" path="descendant::value"/></para>
        /// </summary>
        string Dotnet_Windows_x64 => _Raw.C_ProgramFiles_dotnet;

        /// <summary>
        /// The 32-bit (x32) dotnet location on Windows.
        /// <para><inheritdoc cref="Raw.IDirectoryPaths.C_ProgramFiles_x86_dotnet" path="descendant::value"/></para>
        /// </summary>
        string Dotnet_Windows_x86 => _Raw.C_ProgramFiles_x86_dotnet;

        /// <summary>
        /// The Mac OSX dotnet location.
        /// <para><inheritdoc cref="Raw.IDirectoryPaths.usr_local_share_dotnet" path="descendant::value"/></para>
        /// </summary>
        string Dotnet_OSX => _Raw.usr_local_share_dotnet;

        /// <summary>
        /// The Linux (Unix) dotnet location.
        /// <para><inheritdoc cref="Raw.IDirectoryPaths.usr_share_dotnet" path="descendant::value"/></para>
        /// </summary>
        string Dotnet_Linux => _Raw.usr_share_dotnet;
    }
}
