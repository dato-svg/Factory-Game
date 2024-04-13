using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using UnityEngine;

namespace Assets.Scripts.Saver
{
    public class UnityCloudServisController : MonoBehaviour
    {
        private async void Awake()
        {
            await UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }

        public static async void SaveData<T>(string key, T inData)
        {
            Dictionary<string,object> data = new Dictionary<string, object>(){ {key, inData }};
            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log($"Saved data {string.Join(',', data[key])}");
        }
        
        
        
        
        public static async Task<T> LoadData<T>(string key)
        {
            Dictionary<string, string> data = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> {key});
            var saveData = data[key];
            var saveJson = JsonUtility.FromJson<T>(saveData);
            return saveJson;
            
           
        }
    
    }
}
