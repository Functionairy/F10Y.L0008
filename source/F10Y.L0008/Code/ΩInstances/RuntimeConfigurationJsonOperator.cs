using System;


namespace F10Y.L0008
{
    public class RuntimeConfigurationJsonOperator : IRuntimeConfigurationJsonOperator
    {
        #region Infrastructure

        public static IRuntimeConfigurationJsonOperator Instance { get; } = new RuntimeConfigurationJsonOperator();


        private RuntimeConfigurationJsonOperator()
        {
        }

        #endregion
    }
}
