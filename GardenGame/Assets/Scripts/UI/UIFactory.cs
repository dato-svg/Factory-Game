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


        
        private  void Start()
        {
            updatePrice = 100;
            Key = gameObject.name;
            ResourcesData.LoadResources(Key+"2", ref updatePrice);

        }

        
        private void SaveData()
        {
            ResourcesData.SaveResources(Key+"2",updatePrice);
        }

        
        

        public void ShowPrice()
        {
            updatePriceTxt.text = updatePrice.ToString();
        }

        private void LateUpdate()
        {
            ShowPrice();
            SaveData();
            Debug.Log("Working");
        }
        
    }
}

