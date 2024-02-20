using System;
using Saver;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIFactory : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI updatePriceTxt;
        [SerializeField] private int updatePrice;
        [SerializeField] private UIFactoryData _uiFactoryData;
        
        private IServisSaver _servisSaver;
        private  string Key;
        public int UpdatePrice
        {
            get => updatePrice;
            set => updatePrice = value;
        }


        private void Start()
        {
            Key = gameObject.name;
            _servisSaver = new JsonServisRealize(); // TODO - CHANGE SAVER LOAD SYSTEM
           
            if (_servisSaver.HasData(Key))
            {
                LoadData();
            }
            
            
        }

        private void SaveData()
        {
            _uiFactoryData.UpdatePrice = UpdatePrice;
            _servisSaver.Save(Key, _uiFactoryData);
        }

        private void LoadData()
        {
            _servisSaver.Load<UIFactoryData>(Key,Loader);  // TODO - CHANGE SAVER LOAD SYSTEM
        }

        private void Loader(UIFactoryData uiFactory)
        {
            this.UpdatePrice = uiFactory.UpdatePrice;
        }

        public void ShowPrice()
        {
            updatePriceTxt.text = UpdatePrice.ToString();
        }

        private void FixedUpdate()
        {
            ShowPrice();
            SaveData();
            Debug.Log("Working");
        }
        
    }

    [Serializable]
    public class UIFactoryData
    {
        public int UpdatePrice;
    }
}
