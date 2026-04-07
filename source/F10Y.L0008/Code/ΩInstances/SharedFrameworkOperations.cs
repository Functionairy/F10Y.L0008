using System;


namespace F10Y.L0008
{
    public class SharedFrameworkOperations : ISharedFrameworkOperations
    {
        #region Infrastructure

        public static ISharedFrameworkOperations Instance { get; } = new SharedFrameworkOperations();


        private SharedFrameworkOperations()
        {
        }

        #endregion
    }
}
