using System.Windows;
using ToDoListApp.IOService;
using ToDoListApp.Model;

namespace ToDoListApp
{
    /// <summary>
    /// Interaction Logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.ComponentModel.BindingList<ToDoModel> ToDoDataList;
        private FileIO IOService => new FileIO();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ToDoDataList = IOService.LoadData();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message,
                    ex.GetType().Name, 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);

                System.Environment.Exit(0);
            }

            DgToDoList.ItemsSource = ToDoDataList;

            ToDoDataList.ListChanged += ToDoDataList_ListChanged;
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
                    IOService.SaveData(sender);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), 
                        ex.GetType().Name, 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error);

                    Close();
                }
            }
        }

        private void DgToDoList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) { }
    }
}