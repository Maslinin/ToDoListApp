using System.Threading;
using System.Globalization;

namespace ToDoListApp.Culture
{
    internal static class CultureCustomize
    {
        public static void SetRuCulture()
        {
            var cultureInfo = CultureInfo.CurrentCulture;

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
