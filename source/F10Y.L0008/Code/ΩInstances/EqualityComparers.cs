using System;


namespace F10Y.L0008
{
    public class EqualityComparers : IEqualityComparers
    {
        #region Infrastructure

        public static IEqualityComparers Instance { get; } = new EqualityComparers();


        private EqualityComparers()
        {
        }

        #endregion
    }
}
