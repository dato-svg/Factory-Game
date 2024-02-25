using System;
using System.Threading.Tasks;
using Resources;
using Saver;
using UnityEngine;
using YG;

namespace Controller
{
    public class RewardController : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private GameObject _language;
        [SerializeField] private SaveManager _saveManager;
        private Animator _animator;
        private float _timeDelay= 150f;
        private int _moneyCount = 300;
        private bool isActive = false;
        
        private void Start()
        {
            _saveManager = FindObjectOfType<SaveManager>();
            _target = transform.GetChild(0).gameObject;
            _target.SetActive(false);
            _animator = GetComponent<Animator>();
            EnableObject();
        }
        
        public  void Closer()
        {
            _target.SetActive(false);
            _animator.SetBool("Move",false);
        }

        private async void EnableObject()
        {
            
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(_timeDelay));
                _target.SetActive(true);
                _animator.SetBool("Move",true);
            }
            
        }


        public void GiveReward()
        {
            ResourcesData.MoneyCount += _moneyCount;
            _saveManager.SaveAll();
        }

        public void StartReward()
        {
            YandexGame.RewVideoShow(0);
        }

        public void LanguageChange()
        {
            if (!isActive)
            {
                _language.SetActive(true);
                isActive = true;
            }
            else
            {
                _language.SetActive(false);
                isActive = false;
            }
            
        }
        
    }
}
