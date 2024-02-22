using System.Collections;
using Resources;
using UnityEngine;

namespace Saver
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] private BlockState[] blockStates;
        private const float AutoSaveInterval = 60f;
        private const  string KEY = "Resources";
        
        
        private async void Start()
        {
            LoadData();
            FindBlockStates();
            StartCoroutine(AutoSaver());
        }

        private void FindBlockStates()
        {
            blockStates = FindObjectsOfType<BlockState>();
            if (blockStates == null || blockStates.Length == 0)
            {
                Debug.LogWarning("No BlockState objects found for saving.");
            }
        }

        private IEnumerator AutoSaver()
        {
            while (true)
            {
                yield return new WaitForSeconds(AutoSaveInterval);
                SaveAll();
            }
            
        }

        public void SaveAll()
        {
            if (blockStates == null || blockStates.Length == 0)
            {
                Debug.LogWarning("No BlockState objects found for saving.");
                return;
            }

            foreach (var block in blockStates)
            {
                block.SaveData();
            }
            
          
        }

        private void SaveData()
        {
            ResourcesData.SaveResources(KEY+"MoneyCount",ResourcesData.MoneyCount);
            ResourcesData.SaveResources(KEY+"PhoneCount",ResourcesData.PhoneCount);
            ResourcesData.SaveResources(KEY+"CompCount",ResourcesData.CompCount);
            ResourcesData.SaveResources(KEY+"TVCount",ResourcesData.TVCount);
            ResourcesData.SaveResources(KEY+"PhoneBuffer",ResourcesData.PhoneBuffer);
            ResourcesData.SaveResources(KEY+"CompBuffer",ResourcesData.CompBuffer);
            ResourcesData.SaveResources(KEY+"TVBuffer",ResourcesData.TVBuffer);
        }

        private void LoadData()
        {
            ResourcesData.LoadResources(KEY+"MoneyCount",ref ResourcesData.MoneyCount);
            ResourcesData.LoadResources(KEY+"PhoneCount",ref ResourcesData.PhoneCount);
            ResourcesData.LoadResources(KEY+"CompCount",ref ResourcesData.CompCount);
            ResourcesData.LoadResources(KEY+"TVCount",ref ResourcesData.TVCount);
            ResourcesData.LoadResources(KEY+"PhoneBuffer",ref ResourcesData.PhoneBuffer);
            ResourcesData.LoadResources(KEY+"CompBuffer",ref ResourcesData.CompBuffer);
            ResourcesData.LoadResources(KEY+"TVBuffer",ref ResourcesData.TVBuffer);
        }

        private void LateUpdate()
        {
            SaveData();
        }
    }
}