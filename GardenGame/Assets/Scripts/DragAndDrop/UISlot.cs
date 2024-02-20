using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DragAndDrop
{
    public  class UISlot : MonoBehaviour, IDropHandler
    {
        [SerializeField] private UnityEvent onDestroy;

    
        public void OnDrop(PointerEventData eventData)
        {
            var otherDropped = eventData.pointerDrag.transform;
            otherDropped.GetComponentInParent<Transform>();
            otherDropped.SetParent(transform);
            otherDropped.localPosition = Vector3.zero;
            Destroy(otherDropped.gameObject);
            onDestroy?.Invoke();
        }
    
    }
}