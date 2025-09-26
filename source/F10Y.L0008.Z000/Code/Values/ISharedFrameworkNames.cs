using System;

using F10Y.T0003;


namespace F10Y.L0008.Z000
{
    /// <summary>
    /// Names of .NET shared frameworks.
    /// (Separate from pakcs and SDKs, contains only assembly files.)
    /// </summary>
    /// <remarks>
    /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
    /// <para>
    /// See also: dotnet packs.
    /// </para>
    /// </remarks>
    [ValuesMarker]
    public partial interface ISharedFrameworkNames
    {
        /// <summary>
        /// <para><value>Microsoft.AspNetCore.All</value></para>
        /// </summary>
        const string Microsoft_AspNetCore_All_Constant = "Microsoft.AspNetCore.All";

        /// <inheritdoc cref="ISharedFrameworkNames.Microsoft_AspNetCore_All_Constant"/>
        string Microsoft_AspNetCore_All => ISharedFrameworkNames.Microsoft_AspNetCore_All_Constant;

        /// <summary>
        /// <para><value>Microsoft.AspNetCore.App</value></para>
        /// </summary>
        const string Microsoft_AspNetCore_App_Constant = "Microsoft.AspNetCore.App";

        /// <inheritdoc cref="Microsoft_AspNetCore_App_Constant"/>
        string Microsoft_AspNetCore_App => Microsoft_AspNetCore_App_Constant;

        /// <summary>
        /// <para><value>Microsoft.NETCore.App</value></para>
        /// </summary>
        const string Microsoft_NETCore_App_Constant = "Microsoft.NETCore.App";

        /// <inheritdoc cref="Microsoft_NETCore_App_Constant"/>
        string Microsoft_NETCore_App => Microsoft_NETCore_App_Constant;

        /// <summary>
        /// <para><value>Microsoft.WindowsDesktop.App</value></para>
        /// </summary>
        const string Microsoft_WindowsDesktop_App_Constant = "Microsoft.WindowsDesktop.App";

        /// <inheritdoc cref="Microsoft_WindowsDesktop_App_Constant"/>
        string Microsoft_WindowsDesktop_App => Microsoft_WindowsDesktop_App_Constant;
    }
}
