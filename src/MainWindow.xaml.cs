using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using ToDoListApp.Models;
using ToDoListApp.Services;
using ToDoListApp.Exceptions;

namespace ToDoListApp
{
    public partial class MainWindow : Window
    {
        private BindingList<ToDoModel> _toDoDataList;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ToDoListIOService.CreateFileIfItDoesNotExists();
                this._toDoDataList = ToDoListIOService.LoadData();
            }
            catch(Exception ex)
            {
                ExceptionDisplay.DisplayException(ex);
                base.Close();
            }

            this.DgToDoList.ItemsSource = this._toDoDataList;
            this._toDoDataList.ListChanged += this.ToDoDataList_ListChanged;
        }

        private void ToDoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (ListChangedEventIsTriggered(e))
            {
                try
                {
                    ToDoListIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    ExceptionDisplay.DisplayException(ex);
                    base.Close();
                }
            }
        }

        private static bool ListChangedEventIsTriggered(ListChangedEventArgs e)
        {
            return e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemDeleted ||
                e.ListChangedType == ListChangedType.ItemChanged;
        }

        //empty event handler, because no specific behavior is required
        private void DgToDoList_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
    }
}
