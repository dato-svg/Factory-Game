using System;
using System.IO;
using UnityEngine;

namespace Resources
{
    public static class ResourcesData
    {
        public static int PhoneCount;
        public static int MoneyCount = 20000;
        public static int CompCount;
        public static int TVCount;


        public static int PhoneBuffer = 1;
        public static int CompBuffer = 2;
        public static int TVBuffer = 3;
        
        
        
       
        
        public static void SaveResources(string key, object data)
        {
            string path = BuildPathSaver(key);
            var json = JsonUtility.ToJson(data);
            using (var fileStream = new StreamWriter(path))
            {
                fileStream.Write(json);
            }

        }
        
        public static void LoadResources<T>(string key, Action<T> callback)
        {
            string path = BuildPathSaver(key);
            
           
            using (var fileStream = new StreamReader(path))
            {

                var read = fileStream.ReadToEnd();
                var json = JsonUtility.FromJson<T>(read);
                callback?.Invoke(json);
            }
        }

        public static bool HasLoad(string key)
        {
            string path = BuildPathSaver(key);
            return File.Exists(path);
        }
        
        
        private static string BuildPathSaver(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }
    }

    [Serializable]
    public  class ResourcesDataModel
    {
        public  int PhoneCount;
        public  int MoneyCount = 20000;
        public  int CompCount;
        public  int TVCount;


        public  int PhoneBuffer = 1;
        public  int CompBuffer = 2;
        public  int TVBuffer = 3;
    }
}
