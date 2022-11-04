using System;
using System.ComponentModel;

namespace ToDoListApp.Models
{
    internal sealed class ToDoModel : INotifyPropertyChanged
    {
        public static string CreationDate => DateTime.Now.ToShortDateString();

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isDone;
        private string _text;

        public bool IsDone
        {
            get => this._isDone;
            set
            {
                if (this._isDone == value)
                    return;

                this._isDone = value;
                this.OnPropertyChanged("IsDone");
            }
        }

        public string Text
        {
            get => this._text;
            set
            {
                if (this._text == value)
                    return;

                this._text = value;
                this.OnPropertyChanged("Text");
            }
        }

        //Processing of event (change) in the PropertyChanged
        private void OnPropertyChanged(string PropertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
