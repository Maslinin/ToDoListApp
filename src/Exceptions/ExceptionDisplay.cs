using System;
using System.Windows;

namespace ToDoListApp.Exceptions
{
    internal static class ExceptionDisplay
    {
        public static void DisplayException(Exception ex)
        {
            MessageBox.Show(ex.Message,
                ex.GetType().Name,
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}
