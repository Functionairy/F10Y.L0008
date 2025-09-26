using System;


namespace F10Y.L0008
{
    public class JsonKeys : IJsonKeys
    {
        #region Infrastructure

        public static IJsonKeys Instance { get; } = new JsonKeys();


        private JsonKeys()
        {
        }

        #endregion
    }
}
