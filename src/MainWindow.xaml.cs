using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using ToDoListApp.Models;
using ToDoListApp.IOServices;
using ToDoListApp.Exceptions;

namespace ToDoListApp
{
    /// <summary>
    /// Interaction Logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<ToDoModel> _toDoDataList;
        private readonly IOService _ioService;

        public MainWindow()
        {
            InitializeComponent();
            this._ioService = new IOService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this._ioService.CreateFileIfItDoesNotExists();
                this._toDoDataList = this._ioService.LoadData();
            }
            catch(Exception ex)
            {
                ExceptionDisplayer.DisplayException(ex);
                base.Close();
            }

            this.DgToDoList.ItemsSource = this._toDoDataList;
            this._toDoDataList.ListChanged += this.ToDoDataList_ListChanged;
        }

        private void ToDoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (this.ListChangedEventIsTriggered(e))
            {
                try
                {
                    this._ioService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    ExceptionDisplayer.DisplayException(ex);
                    base.Close();
                }
            }
        }

        private bool ListChangedEventIsTriggered(ListChangedEventArgs e)
        {
            return e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemDeleted ||
                e.ListChangedType == ListChangedType.ItemChanged;
        }

        //empty event handler, because no specific behavior is required
        private void DgToDoList_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
    }
}