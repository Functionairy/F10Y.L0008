using System;


namespace F10Y.L0008
{
    public class RuntimeConfigurationJsonFileOperator : IRuntimeConfigurationJsonFileOperator
    {
        #region Infrastructure

        public static IRuntimeConfigurationJsonFileOperator Instance { get; } = new RuntimeConfigurationJsonFileOperator();


        private RuntimeConfigurationJsonFileOperator()
        {
        }

        #endregion
    }
}
