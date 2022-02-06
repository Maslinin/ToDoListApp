using System.ComponentModel;

namespace ToDoListApp.Model
{
    public sealed class ToDoModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string CreationDate => System.DateTime.Now.ToShortDateString();
        private bool _IsDone;
        private string _Text;

        //Property for the Status column
        public bool IsDone
        {
            get => _IsDone;
            set
            {
                if (_IsDone == value)
                    return;

                _IsDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        //Property for a column with a task
        public string Text
        {
            get => _Text;
            set
            {
                if (_Text == value)
                    return;

                _Text = value;
                OnPropertyChanged("Text");
            }
        }

        //Processing of event (change) in the PropertyChanged
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}