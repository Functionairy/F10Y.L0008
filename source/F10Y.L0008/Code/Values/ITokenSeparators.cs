using System;

using F10Y.T0003;


namespace F10Y.L0008
{
    [ValuesMarker]
    public partial interface ITokenSeparators
    {
        /// <summary>
        /// The token separator for target framework monikers.
        /// <para><inheritdoc cref="F10Y.L0000.IStrings.Dash" path="descendant::description"/></para>
        /// </summary>
        public string For_TargetFrameworkMoniker => Instances.Strings.Dash;

        /// <inheritdoc cref="L0000.IStrings.Slash"/>
        string For_SharedFramework => Instances.Strings.Slash;

        /// <summary>
        /// The token separator for version strings (example: "4.5.1").
        /// <para><inheritdoc cref="F10Y.L0000.IStrings.Period" path="descendant::description"/></para>
        /// </summary>
        public string For_Version => Instances.Strings.Period;
    }
}
