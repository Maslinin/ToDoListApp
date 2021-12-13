using ToDoListApp.IOService;
using ToDoListApp.Model;

namespace ToDoListApp
{
    /// <summary>
    /// Interaction Logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private static System.ComponentModel.BindingList<ToDoModel> _ToDoDataList;
        private static readonly FileIOService _FileIOService = new FileIOService();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                _ToDoDataList = _FileIOService.LoadData();
            }
            catch(System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message,
                    ex.GetType().Name, 
                    System.Windows.MessageBoxButton.OK, 
                    System.Windows.MessageBoxImage.Error);

                System.Environment.Exit(0);
            }

            DgToDoList.ItemsSource = _ToDoDataList;

            _ToDoDataList.ListChanged += ToDoDataList_ListChanged;
        }

        //Event handler when something changes in the list
        private void ToDoDataList_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            //Events to which the sheet responds:
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded || 
                e.ListChangedType == System.ComponentModel.ListChangedType.ItemDeleted || 
                e.ListChangedType == System.ComponentModel.ListChangedType.ItemChanged)
            {
                try
                {
                    _FileIOService.SaveData(sender);
                }
                catch (System.Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, 
                        ex.GetType().Name, 
                        System.Windows.MessageBoxButton.OK, 
                        System.Windows.MessageBoxImage.Error);

                    Close();
                }
            }
        }

        private void DgToDoList_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e) { }
    }
}