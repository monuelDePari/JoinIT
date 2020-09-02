namespace JoinIT.Resources.ITLocalData
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class LanguageInfo
    {
        #region Fields
        private static readonly Dictionary<string, string> _languages =
            new Dictionary<string, string>() { { "English", "en" }, { "Ukrainian", "uk-UA" } };
        #endregion

        #region Properties
        public static Dictionary<string, string> Languages
        {
            get
            {
                return _languages;
            }
        }
        #endregion
    }
}
