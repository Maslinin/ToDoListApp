using System.Threading;
using System.Globalization;

namespace ToDoListApp.Culture
{
    internal static class CultureCustomizer
    {
        public static void SetCurrentCulture()
        {
            var cultureInfo = CultureInfo.CurrentCulture;

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
