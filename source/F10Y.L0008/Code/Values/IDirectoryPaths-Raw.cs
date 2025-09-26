using System;

using F10Y.T0003;


namespace F10Y.L0008.Raw
{
    [ValuesMarker]
    public partial interface IDirectoryPaths
    {
#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// <para><value>C:\Program Files\dotnet\</value></para>
        /// </summary>
        string C_ProgramFiles_dotnet => @"C:\Program Files\dotnet\";

        /// <summary>
        /// <para><value>C:\Program Files (x86)\dotnet\</value></para>
        /// </summary>
        string C_ProgramFiles_x86_dotnet => @"C:\Program Files (x86)\dotnet\";

        /// <summary>
        /// <para><value>/usr/local/share/dotnet/</value></para>
        /// </summary>
        string usr_local_share_dotnet => "/usr/local/share/dotnet/";

        /// <summary>
        /// <para><value>/usr/share/dotnet/</value></para>
        /// </summary>
        string usr_share_dotnet => "/usr/share/dotnet/";

#pragma warning restore IDE1006 // Naming Styles
    }
}
