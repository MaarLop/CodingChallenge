using System.Globalization;
using System.Threading;

namespace CodingChallenge.Data.Helpers
{
    public static class LanguageHelper
    {
        //ver que se puede mejorar para no repetir lineas entre los idiomas
        public static void SetSpanish()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");
        }

        public static void SetEnglish()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }
    }
}