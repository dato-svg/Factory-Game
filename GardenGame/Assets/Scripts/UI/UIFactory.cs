using Resources;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIFactory : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI updatePriceTxt;
        [SerializeField] private int updatePrice;

        private  string Key;
        public int UpdatePrice
        {
            get => updatePrice;
            set => updatePrice = value;
        }


        
        private async void Start()
        {
            Key = gameObject.name;
            var price = UpdatePrice;
            ResourcesData.LoadResources(Key,ref price);
        }

        
        private void SaveData()
        {
            ResourcesData.SaveResources(Key,UpdatePrice);
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

