using System;


namespace F10Y.L0008
{
    public static class Instances
    {
        public static L0000.IHashCodeOperator HashCodeOperator => L0000.HashCodeOperator.Instance;
        public static L0000.INullOperator NullOperator => L0000.NullOperator.Instance;
        public static ISharedFrameworkOperator SharedFrameworkOperator => L0008.SharedFrameworkOperator.Instance;
        public static L0000.IStringOperator StringOperator => L0000.StringOperator.Instance;
        public static L0000.IStrings Strings => L0000.Strings.Instance;
        public static Z000.ITargetFrameworkMonikerTokens TargetFrameworkMonikerTokens => Z000.TargetFrameworkMonikerTokens.Instance;
        public static ITokenSeparators TokenSeparators => L0008.TokenSeparators.Instance;
        public static L0000.IVersionOperator VersionOperator => L0000.VersionOperator.Instance;
        public static L0000.IVersions Versions => L0000.Versions.Instance;
    }
}
