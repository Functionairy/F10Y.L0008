using System;


namespace F10Y.L0008.Z000
{
    public class SharedFrameworkNames : ISharedFrameworkNames
    {
        #region Infrastructure

        public static ISharedFrameworkNames Instance { get; } = new SharedFrameworkNames();


        private SharedFrameworkNames()
        {
        }

        #endregion
    }
}
