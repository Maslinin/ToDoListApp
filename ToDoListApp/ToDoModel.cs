namespace ToDoListApp
{
    //INotifyPropertyChanged - сообщает о изменении значении свойства (что бы отслеживать изменение в списке)
    class ToDoModel : System.ComponentModel.INotifyPropertyChanged
    {
        //Открытое поле, которое будет устанавливать время автоматически
        public string CreationDate { get; set; } = System.DateTime.Now.ToShortDateString();
        //Завершили задачу или нет
        private bool _IsDone;
        //Поле для задачи:
        private string _Text;

        ////Свойство для колонки Статус
        public bool IsDone
        {
            get { return _IsDone; }
            set
            {
                //если IsDone такой же, какой поступает снаружи, ничего не делаем
                if (_IsDone == value) return;
                //Если значение другое, присваиваем его
                _IsDone = value;
                OnPropertyChanged("IsDone");
            }
        }
        //свойство для колонки с задачей
        public string Text
        {
            get { return _Text; }
            set
            {
                if (_Text == value) return;
                _Text = value;
                OnPropertyChanged("Text");
            }
        }

        //PropertyChanged - Когда объект класса изменяет значение свойства,
        //то он через событие PropertyChanged извещает систему об изменении свойства.
        //А система обновляет все привязанные объекты.

        //Реализация интерфейса PropertyChanged
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        //Обработка события (изменения) в PropertyChanged
        private void OnPropertyChanged(string PropertyName = "")
        {
            //PropertyChangedEventArgs - дополнительные данные о событии
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(PropertyName));
        }
    }
}