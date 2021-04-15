//Класс для считывания и записи данных 
namespace ToDoListApp
{
    class FIleIOService
    {
        //Путь, в который мы будем сохранять данные:
        private static readonly string Path = $"{System.Environment.CurrentDirectory}\\ToDoDataList.json";

        //Метод, который будет считывать данные
        public System.ComponentModel.BindingList<ToDoModel> LoadData()
        {
            //Если файла не существует, создаем:
            if (!System.IO.File.Exists(Path))
            {
                System.IO.File.CreateText(Path).Dispose();
                //Так как файл пуст, создаем объект BindingList(пустой, без модели)
                return new System.ComponentModel.BindingList<ToDoModel>();
            }
            using (var Reader = System.IO.File.OpenText(Path))
            {
                //Считывание данных:
                var FileText = Reader.ReadToEnd();              
                //Идет проверка на пустой BindingList
                if (FileText.Length > 0) //P.S Десериализация данных из json в обычный формат и возврат их в BindingList
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<System.ComponentModel.BindingList<ToDoModel>>(FileText);
                return new System.ComponentModel.BindingList<ToDoModel>();
            }
        }

        //Метод, который будет записывать данные на жесткий диск
        public void SaveData(object ToDoDataList)
        {
            using (var Writer = System.IO.File.CreateText(Path))
                Writer.Write(Newtonsoft.Json.JsonConvert.SerializeObject(ToDoDataList));
        }
    }
}