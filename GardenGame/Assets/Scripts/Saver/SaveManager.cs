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

        private GameObject education;
        private int FirstSave = 0;
        
        private  void Start()
        {
            ResourcesData.MoneyCount = 10;
            ResourcesData.PhoneBuffer = 1;
            ResourcesData.CompBuffer = 2;
            ResourcesData.TVBuffer = 3;
            education = GameObject.Find("education");
            FirstSave = PlayerPrefs.GetInt("FistSave",0);
            if (FirstSave == 0)
            {
                SaveData();
                education.SetActive(true);
                
            }
            
            education.SetActive(false);
            LoadData();
            FindBlockStates();
            
        }

        private void FindBlockStates()
        {
            blockStates = FindObjectsOfType<BlockState>();
            if (blockStates == null || blockStates.Length == 0)
            {
                Debug.LogWarning("No BlockState objects found for saving.");
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
            ResourcesData.SaveResources(KEY+"MoneyCount2",ResourcesData.MoneyCount);
            ResourcesData.SaveResources(KEY+"PhoneCount2",ResourcesData.PhoneCount);
            ResourcesData.SaveResources(KEY+"CompCount2",ResourcesData.CompCount);
            ResourcesData.SaveResources(KEY+"TVCount2",ResourcesData.TVCount);
            ResourcesData.SaveResources(KEY+"PhoneBuffer2",ResourcesData.PhoneBuffer);
            ResourcesData.SaveResources(KEY+"CompBuffer2",ResourcesData.CompBuffer);
            ResourcesData.SaveResources(KEY+"TVBuffer2",ResourcesData.TVBuffer);
            PlayerPrefs.SetInt("FistSave",FirstSave);
            FirstSave = 1;
        }

        private void LoadData()
        {
            ResourcesData.LoadResources(KEY + "MoneyCount2", ref ResourcesData.MoneyCount);
            ResourcesData.LoadResources(KEY + "PhoneCount2", ref ResourcesData.PhoneCount);
            ResourcesData.LoadResources(KEY + "CompCount2", ref ResourcesData.CompCount);
            ResourcesData.LoadResources(KEY + "TVCount2", ref ResourcesData.TVCount);
            ResourcesData.LoadResourcesDefault(KEY + "PhoneBuffer2", ref ResourcesData.PhoneBuffer);
            ResourcesData.LoadResourcesDefault(KEY + "CompBuffer2", ref ResourcesData.CompBuffer);
            ResourcesData.LoadResourcesDefault(KEY + "TVBuffer2", ref ResourcesData.TVBuffer);
        }


        private void LateUpdate()
        {
            SaveData();
        }
    }
}