using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class OnTriggerComponent : MonoBehaviour
    {
        [SerializeField] private string tag;
        [SerializeField] private UnityEvent onEnter;
        [SerializeField] private UnityEvent onExit;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(tag))
            {
                onEnter?.Invoke();
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(tag))
            {
                onExit?.Invoke();
            }
        
        }
    }
}

