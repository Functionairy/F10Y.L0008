using System;


namespace F10Y.L0008
{
    public class Instances :
        L0000.Instances
    {
        public static L0000.IComparisonOperator ComparisonOperator => L0000.ComparisonOperator.Instance;
        new public static IDirectoryNames DirectoryNames => L0008.DirectoryNames.Instance;
        public static IDirectoryPaths DirectoryPaths => L0008.DirectoryPaths.Instance;
        public static L0001.L000.IDocumentationFileOperator DocumentationFileOperator => L0001.L000.DocumentationFileOperator.Instance;
        public static IDotnetOperator DotnetOperator => L0008.DotnetOperator.Instance;
        public static IDotnetPackOperator DotnetPackOperator => L0008.DotnetPackOperator.Instance;
        public static L0000.IHashCodeOperator HashCodeOperator => L0000.HashCodeOperator.Instance;
        public static IJsonKeys JsonKeys => L0008.JsonKeys.Instance;
        public static L0060.IJsonOperator JsonOperator => L0060.JsonOperator.Instance;
        public static L0000.IOperatingSystemOperator OperatingSystemOperator => L0000.OperatingSystemOperator.Instance;
        public static IRuntimeConfigurationJsonElementNames RuntimeConfigurationJsonElementNames => L0008.RuntimeConfigurationJsonElementNames.Instance;
        public static IRuntimeConfigurationJsonOperator RuntimeConfigurationJsonOperator => L0008.RuntimeConfigurationJsonOperator.Instance;
        public static ISharedFrameworkOperator SharedFrameworkOperator => L0008.SharedFrameworkOperator.Instance;
        public static ITargetFrameworkMonikerOperator TargetFrameworkMonikerOperator => L0008.TargetFrameworkMonikerOperator.Instance;
        public static ITargetFrameworkMonikers TargetFrameworkMonikers => L0008.TargetFrameworkMonikers.Instance;
        public static Z000.ITargetFrameworkMonikerTokens TargetFrameworkMonikerTokens => Z000.TargetFrameworkMonikerTokens.Instance;
        public static L0001.L000.ITokenOperator TokenOperator => L0001.L000.TokenOperator.Instance;
        public static new ITokenSeparators TokenSeparators => L0008.TokenSeparators.Instance;
        public static ITokens Tokens => L0008.Tokens.Instance;
        public static L0000.IVersions Versions => L0000.Versions.Instance;
    }
}
