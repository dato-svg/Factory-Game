using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Controller
{
    public class RewardController : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        private Animator _animator;
        private float _timeDelay= 5;
        
        private void Start()
        {    
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
        

        
    }
}
