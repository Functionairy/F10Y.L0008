using System;


namespace F10Y.L0008.Z000
{
    public class SharedFrameworkNameSets : ISharedFrameworkNameSets
    {
        #region Infrastructure

        public static ISharedFrameworkNameSets Instance { get; } = new SharedFrameworkNameSets();


        private SharedFrameworkNameSets()
        {
        }

        #endregion
    }
}
