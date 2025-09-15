using System;

using F10Y.T0003;


namespace F10Y.L0008.Z000.Raw
{
    [ValuesMarker]
    public partial interface ITargetFrameworkMonikerTokens
    {
#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// <para><value>android</value></para>
        /// </summary>
        public const string android_Constant = "android";

        /// <inheritdoc cref="android_Constant"/>
        public string android => ITargetFrameworkMonikerTokens.android_Constant;

        /// <summary>
        /// <para><value>ios</value></para>
        /// </summary>
        public const string ios_Constant = "ios";

        /// <inheritdoc cref="ios_Constant"/>
        public string ios => ITargetFrameworkMonikerTokens.ios_Constant;

        /// <summary>
        /// <para><value>maccatalyst</value></para>
        /// </summary>
        public const string maccatalyst_Constant = "maccatalyst";

        /// <inheritdoc cref="maccatalyst_Constant"/>
        public string maccatalyst => ITargetFrameworkMonikerTokens.maccatalyst_Constant;

        /// <summary>
        /// <para><value>macos</value></para>
        /// </summary>
        public const string macos_Constant = "macos";

        /// <inheritdoc cref="macos_Constant"/>
        public string macos => ITargetFrameworkMonikerTokens.macos_Constant;

        /// <summary>
        /// <para><value>tizen</value></para>
        /// </summary>
        public const string tizen_Constant = "tizen";

        /// <inheritdoc cref="tizen_Constant"/>
        public string tizen => ITargetFrameworkMonikerTokens.tizen_Constant;

        /// <summary>
        /// <para><value>tvos</value></para>
        /// </summary>
        public const string tvos_Constant = "tvos";

        /// <inheritdoc cref="tvos_Constant"/>
        public string tvos => ITargetFrameworkMonikerTokens.tvos_Constant;

        /// <summary>
        /// <para><value>windows</value></para>
        /// </summary>
        public const string windows_Constant = "windows";

        /// <inheritdoc cref="windows_Constant"/>
        public string windows => ITargetFrameworkMonikerTokens.windows_Constant;

#pragma warning restore IDE1006 // Naming Styles
    }
}
