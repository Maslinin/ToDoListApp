using System.IO;
using System.ComponentModel;
using Newtonsoft.Json;
using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    internal static class ToDoListIOService
    {
        public static string FilePath => Path.Combine($"{System.Environment.CurrentDirectory}", "ToDoDataList.json");

        public static void CreateFileIfItDoesNotExists()
        {
            if (!File.Exists(FilePath))
            {
                File.CreateText(FilePath).Dispose();
            }
        }

        public static BindingList<ToDoModel> LoadData()
        {
            using StreamReader reader = File.OpenText(FilePath);
            string fileContent = reader.ReadToEnd();
            return GetOrCreateBindingList(fileContent);
        }

        private static BindingList<ToDoModel> GetOrCreateBindingList(string fileContent)
        {
            return (fileContent.Length > 0) ?
                    JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileContent) : new BindingList<ToDoModel>();
        }

        public static void SaveData(object ToDoDataList)
        {
            using var writer = File.CreateText(FilePath);
            writer.Write(JsonConvert.SerializeObject(ToDoDataList));
        }
    }
}
