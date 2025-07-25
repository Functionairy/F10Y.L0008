using System;


namespace F10Y.L0008.Z000
{
    public class TargetFrameworkMonikers : ITargetFrameworkMonikers
    {
        #region Infrastructure

        public static ITargetFrameworkMonikers Instance { get; } = new TargetFrameworkMonikers();


        private TargetFrameworkMonikers()
        {
        }

        #endregion
    }
}
