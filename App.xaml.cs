//Для отображения даты и времени в региональном(Русском варианте) виде
namespace ToDoListApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        //Ключевое слово base используется для доступа к членам базового из производного класса в следующих случаях:
        //Вызов метода базового класса, который был переопределен другим методом.
        //Определение конструктора базового класса, который должен вызываться при создании экземпляров производного класса.

        //Переопределяем метод:
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            var CultureInfo = new System.Globalization.CultureInfo("ru-RU");

            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo;
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = CultureInfo;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = CultureInfo;
            System.Windows.FrameworkElement.LanguageProperty.OverrideMetadata(typeof(System.Windows.FrameworkElement),
                new System.Windows.FrameworkPropertyMetadata(System.Windows.Markup.XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag)));
            //e содержит данные события
            base.OnStartup(e);
        }
    }
}