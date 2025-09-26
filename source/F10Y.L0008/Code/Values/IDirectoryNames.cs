using System;

using F10Y.T0003;
using F10Y.T0011;


namespace F10Y.L0008
{
    [ValuesMarker]
    public partial interface IDirectoryNames :
        L0000.IDirectoryNames
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        L0000.IDirectoryNames _L0000 => L0000.DirectoryNames.Instance;

#pragma warning restore IDE1006 // Naming Styles


#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// <para><value>packs</value></para>
        /// </summary>
        public string packs => "packs";

        /// <summary>
        /// <para><value>ref</value></para>
        /// </summary>
        public string @ref => "ref";

        /// <summary>
        /// <para><value>shared</value></para>
        /// </summary>
        public string shared => "shared";

#pragma warning restore IDE1006 // Naming Styles
    }
}
