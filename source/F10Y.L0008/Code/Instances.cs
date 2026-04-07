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
        new public static L0001.L000.IEqualityComparerOperator EqualityComparerOperator => L0001.L000.EqualityComparerOperator.Instance;
        public static L0000.IHashCodeOperator HashCodeOperator => L0000.HashCodeOperator.Instance;
        public static IJsonKeys JsonKeys => L0008.JsonKeys.Instance;
        public static L0060.IJsonOperator JsonOperator => L0060.JsonOperator.Instance;
        public static L0001.L000.IMappingsOperator MappingsOperator => L0001.L000.MappingsOperator.Instance;
        public static L0000.IOperatingSystemOperator OperatingSystemOperator => L0000.OperatingSystemOperator.Instance;
        public static L0000.IQueueOperator QueueOperator => L0000.QueueOperator.Instance;
        public static IRuntimeConfigurationJsonElementNames RuntimeConfigurationJsonElementNames => L0008.RuntimeConfigurationJsonElementNames.Instance;
        public static IRuntimeConfigurationJsonFileOperator RuntimeConfigurationJsonFileOperator => L0008.RuntimeConfigurationJsonFileOperator.Instance;
        public static IRuntimeConfigurationJsonOperator RuntimeConfigurationJsonOperator => L0008.RuntimeConfigurationJsonOperator.Instance;
        public static ISharedFrameworkOperations SharedFrameworkOperations => L0008.SharedFrameworkOperations.Instance;
        public static ISharedFrameworkOperator SharedFrameworkOperator => L0008.SharedFrameworkOperator.Instance;
        public static ITargetFrameworkMonikerOperator TargetFrameworkMonikerOperator => L0008.TargetFrameworkMonikerOperator.Instance;
        public static ITargetFrameworkMonikers TargetFrameworkMonikers => L0008.TargetFrameworkMonikers.Instance;
        public static Z000.ITargetFrameworkMonikerTokens TargetFrameworkMonikerTokens => Z000.TargetFrameworkMonikerTokens.Instance;
        public static ITemplateStrings TemplateStrings => L0008.TemplateStrings.Instance;
        public static L0001.L000.ITexts Texts => L0001.L000.Texts.Instance;
        public static L0001.L000.ITokenOperator TokenOperator => L0001.L000.TokenOperator.Instance;
        public static new ITokenSeparators TokenSeparators => L0008.TokenSeparators.Instance;
        public static ITokens Tokens => L0008.Tokens.Instance;
        public static L0000.IVersions Versions => L0000.Versions.Instance;
    }
}
