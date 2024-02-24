using System;
using System.IO;
using UnityEngine;

namespace Resources
{
    public static class ResourcesData
    {
        public static int PhoneCount;
        public static int MoneyCount;
        public static int CompCount;
        public static int TVCount;


        public static int PhoneBuffer;
        public static int CompBuffer;
        public static int TVBuffer;
        
        
        
       
        
        public static void SaveResources(string key, int data)
        {
            PlayerPrefs.SetInt(key,data);
            
        }
        
        public static void LoadResources(string key,ref int data)
        {
            if (key != null)
            {
                data = PlayerPrefs.GetInt(key); 
            }
          
        }
        
        
        public static void LoadResourcesDefault(string key,ref int data)
        {
            data = PlayerPrefs.GetInt(key,1);
        }

      
        
        
        
        
    }
}
