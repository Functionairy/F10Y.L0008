using System;

using F10Y.T0001;


namespace F10Y.L0008
{
	public static partial class Documentation
	{
        [DocumentationsMarker]
        public static partial class For_SharedFrameworks
        {
            /// <summary>
            /// Example shared frameworks directory path: <value>C:\Program Files\dotnet\shared\</value>
            /// </summary>
            public static readonly object Example_SharedFrameworks_DirectoryPath;

            /// <summary>
            /// Example shared framework root directory path: <value>C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\</value>
            /// </summary>
            public static readonly object Example_SharedFrameworkRoot_DirectoryPath;

            /// <summary>
            /// Example shared framework directory path: <value>C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\5.0.17\</value>
            /// </summary>
            public static readonly object Example_SharedFramework_DirectoryPath;
        }
    }
}