using System;


namespace F10Y.L0008
{
    public class DotnetOperator : IDotnetOperator
    {
        #region Infrastructure

        public static IDotnetOperator Instance { get; } = new DotnetOperator();


        private DotnetOperator()
        {
        }

        #endregion
    }
}
