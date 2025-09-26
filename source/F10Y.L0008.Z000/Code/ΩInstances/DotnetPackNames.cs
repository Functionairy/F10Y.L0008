using System;


namespace F10Y.L0008.Z000
{
    public class DotnetPackNames : IDotnetPackNames
    {
        #region Infrastructure

        public static IDotnetPackNames Instance { get; } = new DotnetPackNames();


        private DotnetPackNames()
        {
        }

        #endregion
    }
}
