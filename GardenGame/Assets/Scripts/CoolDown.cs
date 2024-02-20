using System;
using UnityEngine;


[Serializable]
    public class CoolDown
    {
        [SerializeField] private float timer;
        public float Timer => timer;
        
        private float _timesUp;
        
        public bool IsReady => _timesUp <= Time.time;


        public void Reset()
        {
            _timesUp = Time.time + timer;
        }

      
    }  
