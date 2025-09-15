using System;


namespace F10Y.L0008
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
