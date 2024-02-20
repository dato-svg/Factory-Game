using System.Collections;
using Controller;
using UI;
using UnityEngine;

namespace Resources
{
    public class ResourcesGive : MonoBehaviour
    {   
        public int lifeTime;
        [SerializeField] private int giveResources;
        [SerializeField] private int takeMoneyDelay = 1;
        [SerializeField] private int restartFactory;
    
    
        private int _currentLifeTime;
        private UIGameManager _uiGameManager;
        private PlayerController _player;
        private bool _continueCoroutine = true;


        private void Start()
        {
            _uiGameManager = FindObjectOfType<UIGameManager>();
            _player = FindObjectOfType<PlayerController>();
            _currentLifeTime = lifeTime;
            _currentLifeTime = Mathf.Clamp(_currentLifeTime, 0, lifeTime);
        }
    
    
    
  

        public void GivePhoneResources()
        {     
            StopAllCoroutines();
            _continueCoroutine = true;
            StartCoroutine(WaitTakePhone());
        }
    
   
        public void StopAllCaroutine()
        {
            _continueCoroutine = false;
            _player.TakePhone(false);
            StopAllCoroutines();
            StartCoroutine(ReloadPhoneResources());
        }

        private IEnumerator WaitTakePhone()
        {
            while (_currentLifeTime > 0)
            { 
                _player.TakePhone(true);
                yield return new WaitForSeconds(takeMoneyDelay);
                _currentLifeTime--;
                ResourcesData.PhoneCount += giveResources;
                _uiGameManager.ShowResources();


            }

            _player.TakePhone(false);
            StartCoroutine(ReloadPhoneResources());
        
        }

        private IEnumerator ReloadPhoneResources()
        {
            yield return null;
            yield return  new WaitForSeconds(restartFactory);
            if (_currentLifeTime <= 0)
            {
                _currentLifeTime = lifeTime;
                if (_continueCoroutine)
                {
                    StartCoroutine(WaitTakePhone());
                }
            }
        }
    
        public void GiveCompResources()
        {     
            StopAllCoroutines();
            _continueCoroutine = true;
            StartCoroutine(WaitTakeComp());
        }
    
    
        public void StopAllCaroutineComp()
        {
            _continueCoroutine = false;
            _player.TakePhone(false);
            StopAllCoroutines();
            StartCoroutine(ReloadCompResources());
        }
    
    
        private IEnumerator WaitTakeComp()
        {
            while (_currentLifeTime > 0)
            { 
                _player.TakePhone(true);
                yield return new WaitForSeconds(takeMoneyDelay);
                _currentLifeTime--;
                ResourcesData.CompCount += giveResources;
                _uiGameManager.ShowResources();


            }

            _player.TakePhone(false);
            StartCoroutine(ReloadCompResources());
        
        }
    
    
        private IEnumerator ReloadCompResources()
        {
            yield return null;
            yield return  new WaitForSeconds(restartFactory);
            if (_currentLifeTime <= 0)
            {
                _currentLifeTime = lifeTime;
                if (_continueCoroutine)
                {
                    StartCoroutine(WaitTakeComp());
                }
            }
        }
        
        
        public void GiveTVResources()
        {     
            StopAllCoroutines();
            _continueCoroutine = true;
            StartCoroutine(WaitTakeTV());
        }
        
        public void StopAllCaroutineTV()
        {
            _continueCoroutine = false;
            _player.TakePhone(false);
            StopAllCoroutines();
            StartCoroutine(ReloadTVResources());
        }
        
        private IEnumerator WaitTakeTV()
        {
            while (_currentLifeTime > 0)
            { 
                _player.TakePhone(true);
                yield return new WaitForSeconds(takeMoneyDelay);
                _currentLifeTime--;
                ResourcesData.TVCount += giveResources;
                _uiGameManager.ShowResources();


            }

            _player.TakePhone(false);
            StartCoroutine(ReloadTVResources());
        
        }
        
        private IEnumerator ReloadTVResources()
        {
            yield return null;
            yield return  new WaitForSeconds(restartFactory);
            if (_currentLifeTime <= 0)
            {
                _currentLifeTime = lifeTime;
                if (_continueCoroutine)
                {
                    StartCoroutine(WaitTakeTV());
                }
            }
        }
    }
}