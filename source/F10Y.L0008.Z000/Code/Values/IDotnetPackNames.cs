using System;

using F10Y.T0003;


namespace F10Y.L0008.Z000
{
    /// <summary>
    /// Names of .NET packs.
    /// (Separate from shared frameworks, more like SDKs, and contains documentation files.)
    /// </summary>
    /// <remarks>
    /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
    /// <para>
    /// See also: <see cref="ISharedFrameworkNames"/>.
    /// </para>
    /// </remarks>
    [ValuesMarker]
    public partial interface IDotnetPackNames
    {
        /// <summary>
        /// <para><value>Microsoft.AspNetCore.App.Ref</value></para>
        /// </summary>
        const string Microsoft_AspNetCore_App_Ref_Constant = "Microsoft.AspNetCore.App.Ref";

        /// <inheritdoc cref="Microsoft_AspNetCore_App_Ref_Constant"/>
        string Microsoft_AspNetCore_App_Ref => Microsoft_AspNetCore_App_Ref_Constant;

        /// <summary>
        /// <para><value>Microsoft.NETCore.App.Ref</value></para>
        /// </summary>
        const string Microsoft_NETCore_App_Ref_Constant = "Microsoft.NETCore.App.Ref";

        /// <inheritdoc cref="Microsoft_NETCore_App_Ref_Constant"/>
        string Microsoft_NETCore_App_Ref => Microsoft_NETCore_App_Ref_Constant;

        /// <summary>
        /// <para><value>Microsoft.WindowsDesktop.App.Ref</value></para>
        /// </summary>
        string Microsoft_WindowsDesktop_App_Ref_Constant => "Microsoft.WindowsDesktop.App.Ref";

        /// <inheritdoc cref="Microsoft_WindowsDesktop_App_Ref_Constant"/>
        string Microsoft_WindowsDesktop_App_Ref => Microsoft_WindowsDesktop_App_Ref_Constant;

        /// <summary>
        /// <para><value>NETStandard.Library.Ref</value></para>
        /// </summary>
        string NETStandard_Library_Ref_Constant => "NETStandard.Library.Ref";

        /// <inheritdoc cref="NETStandard_Library_Ref_Constant"/>
        string NETStandard_Library_Ref => NETStandard_Library_Ref_Constant;
    }
}
