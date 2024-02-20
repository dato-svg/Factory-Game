using System.Collections;
using Resources;
using UnityEngine;

namespace Saver
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] private BlockState[] blockStates;
        [SerializeField]  private ResourcesDataModel resourcesModel;
        private const float AutoSaveInterval = 60f;
        private const  string KEY = "Resources";
        
        
        private void Start()
        {
            if (ResourcesData.HasLoad(KEY))
            {
                ResourcesData.LoadResources<ResourcesDataModel>(KEY,LoadData); //TODO - CHANGE LOAD SYSTEM
            }
           
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
            resourcesModel.PhoneCount =  ResourcesData.PhoneCount;
            resourcesModel.MoneyCount = ResourcesData.MoneyCount;
            resourcesModel.CompCount = ResourcesData.CompCount;
            resourcesModel.TVCount = ResourcesData.TVCount;
            resourcesModel.PhoneBuffer = ResourcesData.PhoneBuffer;
            resourcesModel.CompBuffer = ResourcesData.CompBuffer;
            resourcesModel.TVBuffer = ResourcesData.TVBuffer;
            ResourcesData.SaveResources(KEY,resourcesModel); //TODO - CHANGE SAVER SYSTEM
        }

        private void LoadData(ResourcesDataModel resourcesDataModel)
        {
            ResourcesData.PhoneCount = resourcesDataModel.PhoneCount;
            ResourcesData.MoneyCount = resourcesDataModel.MoneyCount;
            ResourcesData.CompCount = resourcesDataModel.CompCount;
            ResourcesData.TVCount = resourcesDataModel.TVCount;
            ResourcesData.PhoneBuffer = resourcesDataModel.PhoneBuffer;
            ResourcesData.CompBuffer = resourcesDataModel.CompBuffer;
            ResourcesData.TVBuffer = resourcesDataModel.TVBuffer;
        }

        private void Update()
        {
            SaveData();
        }
    }
}