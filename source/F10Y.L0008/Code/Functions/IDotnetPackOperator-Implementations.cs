using System;

using F10Y.T0002;


namespace F10Y.L0008.Implementations
{
    [FunctionsMarker]
    public partial interface IDotnetPackOperator
    {
        /// <inheritdoc cref="L0008.IDotnetPackOperator.Get_PackName_FromSharedFrameworkName(string)"/>
        /// <remarks>
        /// Appends the reference token ("<inheritdoc cref="ITokens.Ref" path="descendant::value"/>") to the dotnet shared framework name to get the dotnet pack name.
        /// <para>
        /// This seems to be a "good enough" solution.
        /// </para>
        /// </remarks>
        public string Get_PackName_FromSharedFrameworkName_ByAppendingRefToken(string sharedFrameworkName)
            => Instances.TokenOperator.Combine(
                Instances.TokenSeparators.For_DotnetPackName,
                sharedFrameworkName,
                Instances.Tokens.Ref);
    }
}
