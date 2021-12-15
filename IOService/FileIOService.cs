using System.IO;
using System.ComponentModel;
using ToDoListApp.Model;
using Newtonsoft.Json;

namespace ToDoListApp.IOService
{
    sealed class FileIOService
    {
        private static readonly string FilePath = Path.Combine($"{System.Environment.CurrentDirectory}", "ToDoDataList.json");

        public BindingList<ToDoModel> LoadData()
        {
            if (!File.Exists(FilePath))
            {
                File.CreateText(FilePath).Dispose();
                return new BindingList<ToDoModel>();
            }

            using (var Reader = File.OpenText(FilePath))
            {
                var FileText = Reader.ReadToEnd();    
                
                if (FileText.Length > 0)
                    return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(FileText);
                return new BindingList<ToDoModel>();
            }
        }

        public void SaveData(object ToDoDataList)
        {
            using (var Writer = File.CreateText(FilePath))
                Writer.Write(JsonConvert.SerializeObject(ToDoDataList));
        }
    }
}