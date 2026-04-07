using System;

using F10Y.T0003;


namespace F10Y.L0008
{
    [ValuesMarker]
    public partial interface ITokens
    {
#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// <para><value>.Ref</value></para>
        /// </summary>
        string dotRef => ".Ref";

        /// <summary>
        /// <para><value>Ref</value></para>
        /// </summary>
        string Ref => "Ref";

#pragma warning restore IDE1006 // Naming Styles
    }
}
