using System.Threading;
using System.Globalization;

namespace ToDoListApp.Culture
{
    internal static class CultureCustomizer
    {
        public static void SetRuCulture()
        {
            var cultureInfo = new CultureInfo("ru-RU");

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
