using System;


namespace F10Y.L0008
{
    public class Tokens : ITokens
    {
        #region Infrastructure

        public static ITokens Instance { get; } = new Tokens();


        private Tokens()
        {
        }

        #endregion
    }
}
