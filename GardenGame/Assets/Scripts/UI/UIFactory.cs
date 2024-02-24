using Resources;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIFactory : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI updatePriceTxt;
        public int UpdatePrice;

        private int FirstSaveStart = 0;
        private  string Key;
        


        
        private  void Start()
        {
            Key = gameObject.name;
            FirstSaveStart = PlayerPrefs.GetInt(Key +"FirstSaveStart", 0);
            if (FirstSaveStart == 0)
            {
                UpdatePrice = 100;
                SaveData();
            }
            else
            {
                ResourcesData.LoadResources(Key+"2", ref UpdatePrice);
            }
           
          

        }

        
        private void SaveData()
        {
            ResourcesData.SaveResources(Key+"2",UpdatePrice);
            FirstSaveStart = 1;
            PlayerPrefs.SetInt(Key +"FirstSaveStart",FirstSaveStart);
        }

        
        

        public void ShowPrice()
        {
            updatePriceTxt.text = UpdatePrice.ToString();
        }

        private void LateUpdate()
        {
            ShowPrice();
            SaveData();
            Debug.Log("Working");
        }
        
    }
}

