using Resources;
using Saver;
using TMPro;
using UnityEngine;
using YG;

namespace Controller
{
    public class RewardController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _priceOne;
        [SerializeField] private TextMeshProUGUI _priceTwo;
        [SerializeField] private int _moneyCountOne = 300;
        [SerializeField] private int _defaultMoneyOne = 300;
        
        [SerializeField] private int _moneyCountTwo = 50000;
        [SerializeField] private int _defaultMoneyTwo = 50000;
        [SerializeField] private int IndexReward = 1;
        private SaveManager _saveManager;
        private string Key;
        [SerializeField] private AudioSource[] _listener;

        private void Start()
        {
            Key = gameObject.name;
            _moneyCountOne = PlayerPrefs.GetInt(Key + "10",_defaultMoneyOne);
            _moneyCountTwo = PlayerPrefs.GetInt(Key + "12",_defaultMoneyTwo);
            _saveManager = FindObjectOfType<SaveManager>();
        }

       

        private void LateUpdate()
        {
            _priceOne.text = _moneyCountOne.ToString();
            _priceTwo.text = _moneyCountTwo.ToString();
            SaveMoney();
            Debug.Log(IndexReward);
        }



        public void GiveReward()
        {
            
            
            if (IndexReward == 1)
            {
                ResourcesData.MoneyCount += _moneyCountOne;
                _moneyCountOne *= 2; 
                SaveMoney();
                _saveManager.SaveAll();  
            }

            if (IndexReward == 2)
            {
                ResourcesData.MoneyCount += _moneyCountTwo;
                _moneyCountTwo *= 2; 
                SaveMoney();
                _saveManager.SaveAll();  
            }
        }

        public void ChangeIndex(int index)
        {
            IndexReward = index;
        }

        public void StartReward()
        {
            YandexGame.RewVideoShow(0);
        }

        public void GameController(float volume)
        {
            foreach (var item in _listener)
            {
                item.volume = volume;
            }
        }

        

        private void SaveMoney()
        {
            PlayerPrefs.SetInt(Key + "10",_moneyCountOne);
            PlayerPrefs.SetInt(Key + "12",_moneyCountTwo);
        }


    }
}