using System.ComponentModel;

namespace ToDoListApp.Model
{
    sealed class ToDoModel : INotifyPropertyChanged
    {
        //Open field that will set the time automatically
        public string CreationDate { get; private set; } = System.DateTime.Now.ToShortDateString();
        //Completed task or not
        public bool _IsDone { get; private set; }
        //Task Field:
        public string _Text { get; private set; }

        //Property for the Status column
        public bool IsDone
        {
            get { return _IsDone; }
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
            get { return _Text; }
            set
            {
                if (_Text == value) 
                    return;

                _Text = value;
                OnPropertyChanged("Text");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        //Processing of event (change) in the PropertyChanged
        private void OnPropertyChanged(string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}