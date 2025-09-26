using System;

using F10Y.T0003;


namespace F10Y.L0008
{
    [ValuesMarker]
    public partial interface IJsonKeys
    {
#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// <para><value>framework</value></para>
        /// </summary>
        public string framework => "framework";

        /// <summary>
        /// <para><value>frameworks</value></para>
        /// </summary>
        public string frameworks => "frameworks";

        /// <summary>
        /// <para><value>runtimeOptions</value></para>
        /// </summary>
        public string runtimeOptions => "runtimeOptions";

        /// <summary>
        /// <para><value>runtimeTarget</value></para>
        /// </summary>
        public string runtimeTarget => "runtimeTarget";

        /// <summary>
        /// <para><value>name</value></para>
        /// </summary>
        public string name => "name";

        /// <summary>
        /// <para><value>version</value></para>
        /// </summary>
        public string version => "version";

#pragma warning restore IDE1006 // Naming Styles
    }
}
