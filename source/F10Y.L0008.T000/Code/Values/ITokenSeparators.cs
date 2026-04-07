using System;

using F10Y.T0003;


namespace F10Y.L0008.T000
{
    [ValuesMarker]
    public partial interface ITokenSeparators
    {
        /// <inheritdoc cref="L0000.IStrings.Slash"/>
        string For_SharedFramework => Instances.Strings.Slash;
    }
}
