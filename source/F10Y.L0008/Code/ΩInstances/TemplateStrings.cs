using System;


namespace F10Y.L0008
{
    public class TemplateStrings : ITemplateStrings
    {
        #region Infrastructure

        public static ITemplateStrings Instance { get; } = new TemplateStrings();


        private TemplateStrings()
        {
        }

        #endregion
    }
}
