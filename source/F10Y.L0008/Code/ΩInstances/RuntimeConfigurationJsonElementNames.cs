using System;


namespace F10Y.L0008
{
    public class RuntimeConfigurationJsonElementNames : IRuntimeConfigurationJsonElementNames
    {
        #region Infrastructure

        public static IRuntimeConfigurationJsonElementNames Instance { get; } = new RuntimeConfigurationJsonElementNames();


        private RuntimeConfigurationJsonElementNames()
        {
        }

        #endregion
    }
}
