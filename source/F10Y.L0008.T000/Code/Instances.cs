using System;


namespace F10Y.L0008.T000
{
    public static class Instances
    {
        public static L0000.IComparisonOperator ComparisonOperator => L0000.ComparisonOperator.Instance;
        public static L0000.IHashCodeOperator HashCodeOperator => L0000.HashCodeOperator.Instance;
        public static L0000.INullOperator NullOperator => L0000.NullOperator.Instance;
        public static ISharedFrameworkOperator SharedFrameworkOperator => T000.SharedFrameworkOperator.Instance;
        public static L0000.IStringOperator StringOperator => L0000.StringOperator.Instance;
        public static L0000.IStrings Strings => L0000.Strings.Instance;
        public static L0001.L000.ITexts Texts => L0001.L000.Texts.Instance;
        public static ITokenSeparators TokenSeparators => T000.TokenSeparators.Instance;
        public static L0000.IVersionOperator VersionOperator => L0000.VersionOperator.Instance;
    }
}