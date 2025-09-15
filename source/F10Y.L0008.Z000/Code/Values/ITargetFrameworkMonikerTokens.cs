using System;

using F10Y.T0003;
using F10Y.T0011;


namespace F10Y.L0008.Z000
{
    [ValuesMarker]
    public partial interface ITargetFrameworkMonikerTokens
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        Raw.ITargetFrameworkMonikerTokens _Raw => Raw.TargetFrameworkMonikerTokens.Instance;

#pragma warning restore IDE1006 // Naming Styles

#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// <para><value>netstandard</value></para>
        /// </summary>
        public string netstandard => "netstandard";

        /// <inheritdoc cref="Raw.ITargetFrameworkMonikerTokens.windows"/>
        public string windows => _Raw.windows;

#pragma warning restore IDE1006 // Naming Styles
    }
}
