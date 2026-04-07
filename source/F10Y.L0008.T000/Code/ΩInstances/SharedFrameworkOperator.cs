using System;


namespace F10Y.L0008.T000
{
    public class SharedFrameworkOperator : ISharedFrameworkOperator
    {
        #region Infrastructure

        public static ISharedFrameworkOperator Instance { get; } = new SharedFrameworkOperator();


        private SharedFrameworkOperator()
        {
        }

        #endregion
    }
}
