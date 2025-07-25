using System;

using F10Y.T0003;


namespace F10Y.L0008.Z000
{
    [ValuesMarker]
    public partial interface ITargetFrameworkMonikers
    {
        /// <summary>
        /// <para><value>LATEST</value></para>
        /// </summary>
        public const string LATEST_Constant = "LATEST";

        /// <inheritdoc cref="LATEST_Constant"/>
        public string LATEST => LATEST_Constant;
    }
}
