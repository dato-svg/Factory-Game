using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class OnCollisionComponent : MonoBehaviour
    {
        [SerializeField] private string tag;
        [SerializeField] private UnityEvent onEnter;
        [SerializeField] private UnityEvent onExit;
        
        private bool _isEnabled = true;
        
        public void EnableComponent()
        {
            _isEnabled = true;
        }

        public void DisableComponent()
        {
           _isEnabled = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_isEnabled && other.gameObject.CompareTag(tag))
            {
                onEnter?.Invoke();
            }
        
        }
    
        private void OnCollisionExit(Collision other)
        {
            if (_isEnabled && other.gameObject.CompareTag(tag))
            {
                onExit?.Invoke();
            }
        
        }
    
    
    }
}
