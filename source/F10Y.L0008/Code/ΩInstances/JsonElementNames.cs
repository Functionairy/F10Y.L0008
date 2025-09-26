using System;


namespace F10Y.L0008
{
    public class JsonElementNames : IJsonElementNames
    {
        #region Infrastructure

        public static IJsonElementNames Instance { get; } = new JsonElementNames();


        private JsonElementNames()
        {
        }

        #endregion
    }
}
