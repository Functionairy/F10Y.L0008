using System;


namespace F10Y.L0008
{
    public class TargetFrameworkMonikerOperator : ITargetFrameworkMonikerOperator
    {
        #region Infrastructure

        public static ITargetFrameworkMonikerOperator Instance { get; } = new TargetFrameworkMonikerOperator();


        private TargetFrameworkMonikerOperator()
        {
        }

        #endregion
    }
}
