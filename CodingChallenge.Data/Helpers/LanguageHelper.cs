using System.Globalization;
using System.Threading;

namespace CodingChallenge.Data.Helpers
{
    public static class LanguageHelper
    {
        public static void SetSpanish()
        {
            SetLanguage("es-AR");
        }

        public static void SetEnglish()
        {
            SetLanguage("en-US");
        }

        private static void SetLanguage(string name)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(name);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
        }
    }
}