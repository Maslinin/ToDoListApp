//Основной код программы:
namespace ToDoListApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        //Список задач/создание коллекции
        private static System.ComponentModel.BindingList<ToDoModel> _ToDoDataList;
        //Объект класса FileIOService
        private static readonly FIleIOService _FileIOService = new FIleIOService();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Здесь будут хранится данные из заметок в файле
        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                //Обрщаемся к жесткому диску и загружаем данные из файла в ToDoDataList
                _ToDoDataList = _FileIOService.LoadData();
            }
            //Выводим сообщение о конкретной ошибке на экран:
            catch(System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Ошибка в работе", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                //Закрываем приложение
                System.Environment.Exit(0);
            }

            //ItemSourse задает коллекцию
            //DgToDoList - название DataGrid
            DgToDoList.ItemsSource = _ToDoDataList;
            //Когда что то обновляется в списке, вызывается событие, что бы данные на HDD обновились
            _ToDoDataList.ListChanged += ToDoDataList_ListChanged;
        }

        //Обработчик событий, когда что-то изменяется в списке
        private void ToDoDataList_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            //События, на которые реагирует лист:
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded || 
                e.ListChangedType == System.ComponentModel.ListChangedType.ItemDeleted || 
                e.ListChangedType == System.ComponentModel.ListChangedType.ItemChanged)
            {
                try
                {
                    //Сейвим данные из ToDoDataList
                    _FileIOService.SaveData(sender);
                }
                //Выводим сообщение о конкретной ошибке на экран:
                catch (System.Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, "Ошибка в работе", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    //Закрываем приложение
                    Close();
                }
            }
        }

        private void DgToDoList_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e) { }
    }
}