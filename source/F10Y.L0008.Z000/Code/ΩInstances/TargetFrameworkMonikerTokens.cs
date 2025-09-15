using System;


namespace F10Y.L0008.Z000
{
    public class TargetFrameworkMonikerTokens : ITargetFrameworkMonikerTokens
    {
        #region Infrastructure

        public static ITargetFrameworkMonikerTokens Instance { get; } = new TargetFrameworkMonikerTokens();


        private TargetFrameworkMonikerTokens()
        {
        }

        #endregion
    }
}


namespace F10Y.L0008.Z000.Raw
{
    public class TargetFrameworkMonikerTokens : ITargetFrameworkMonikerTokens
    {
        #region Infrastructure

        public static ITargetFrameworkMonikerTokens Instance { get; } = new TargetFrameworkMonikerTokens();


        private TargetFrameworkMonikerTokens()
        {
        }

        #endregion
    }
}