using System;

using F10Y.T0003;


namespace F10Y.L0008
{
    [ValuesMarker]
    public partial interface IRuntimeConfigurationJsonElementNames
    {
        private static readonly IJsonElementNames _JsonElementNames = JsonElementNames.Instance;


#pragma warning disable IDE1006 // Naming Styles

        /// <inheritdoc cref="IJsonElementNames.framework"/>
        public string framework => _JsonElementNames.framework;

        /// <inheritdoc cref="IJsonElementNames.frameworks"/>
        public string frameworks => _JsonElementNames.frameworks;

        /// <inheritdoc cref="IJsonElementNames.name"/>
        public string name => _JsonElementNames.name;

        /// <inheritdoc cref="IJsonElementNames.runtimeOptions"/>
        public string runtimeOptions => _JsonElementNames.runtimeOptions;

        /// <inheritdoc cref="IJsonElementNames.tfm"/>
        public string tfm => _JsonElementNames.tfm;

        /// <inheritdoc cref="IJsonElementNames.version"/>
        public string version => _JsonElementNames.version;

#pragma warning restore IDE1006 // Naming Styles
    }
}
