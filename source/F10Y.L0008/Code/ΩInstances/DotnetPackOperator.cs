using System;


namespace F10Y.L0008
{
    public class DotnetPackOperator : IDotnetPackOperator
    {
        #region Infrastructure

        public static IDotnetPackOperator Instance { get; } = new DotnetPackOperator();


        private DotnetPackOperator()
        {
        }

        #endregion
    }
}


namespace F10Y.L0008.Implementations
{
    public class DotnetPackOperator : IDotnetPackOperator
    {
        #region Infrastructure

        public static IDotnetPackOperator Instance { get; } = new DotnetPackOperator();


        private DotnetPackOperator()
        {
        }

        #endregion
    }
}
