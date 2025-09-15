using System;

using F10Y.T0003;


namespace F10Y.L0008.Z000
{
    [ValuesMarker]
    public partial interface ISharedFrameworkNames
    {
        /// <summary>
        /// <para><value>Microsoft.AspNetCore.All</value></para>
        /// </summary>
        string Microsoft_AspNetCore_All => "Microsoft.AspNetCore.All";

        /// <summary>
        /// <para><value>Microsoft.AspNetCore.App</value></para>
        /// </summary>
        string Microsoft_AspNetCore_App => "Microsoft.AspNetCore.App";

        /// <summary>
        /// <para><value>Microsoft.NETCore.App</value></para>
        /// </summary>
        string Microsoft_NETCore_App => "Microsoft.NETCore.App";

        /// <summary>
        /// <para><value>Microsoft.WindowsDesktop.App</value></para>
        /// </summary>
        string Microsoft_WindowsDesktop_App => "Microsoft.WindowsDesktop.App";
    }
}
