using System.Windows;
using ToDoListApp.Culture;

namespace ToDoListApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            CultureCustomizer.SetCurrentCulture();

            base.OnStartup(e);
        }
    }
}