//Класс для считывания и записи данных 
namespace ToDoListApp.DataRead
{
    class FIleIOService
    {
        //Путь, в который мы будем сохранять данные:
        private static readonly string Path = $"{System.Environment.CurrentDirectory}\\ToDoDataList.json";

        //Метод, который будет считывать данные
        public System.ComponentModel.BindingList<Models.ToDoModel> LoadData()
        {
            //Если файла не существует, создаем:
            if (!System.IO.File.Exists(Path))
            {
                //Dispose() - свобождает все ресурсы, используемые объектом TextWriter
                System.IO.File.CreateText(Path).Dispose();
                //Так как файл пуст, создаем объект BindingList(пустой, без модели)
                return new System.ComponentModel.BindingList<Models.ToDoModel>();
            }
            using (var Reader = System.IO.File.OpenText(Path))
            {
                //Считывание данных:
                var FileText = Reader.ReadToEnd();              
                //Идет проверка на пустой BindingList
                if (FileText.Length > 0) //P.S Десериализация данных из json в обычный формат и возврат их в BindingList
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<System.ComponentModel.BindingList<Models.ToDoModel>>(FileText);
                return new System.ComponentModel.BindingList<Models.ToDoModel>();
            }
        }

        //Метод, который будет записывать данные на жесткий диск
        //Аргумент - BindingList, т.е. данные
        public void SaveData(object ToDoDataList)
        {
            // using что бы освободить ресурсы для записи в файл 
            using (var Writer = System.IO.File.CreateText(Path))
            {
                //лист сериализируем с помощью Json конвертера
                string OutPut = Newtonsoft.Json.JsonConvert.SerializeObject(ToDoDataList);
                //записывает даннные на жесткий диск
                Writer.Write(OutPut);
            }
        }
    }
}