using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DragAndDrop
{
    public class UIItem : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
    {
    
        [SerializeField] private bool isBack = true;
        [SerializeField] private UnityEvent onBeginDragEvent;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private Canvas _canvas;
    

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvas = GetComponentInParent<Canvas>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {    
            onBeginDragEvent?.Invoke();
            _canvasGroup.blocksRaycasts = false;
            var item = _rectTransform.parent;
            item.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (isBack)
            {
                _rectTransform.localPosition = Vector3.zero;
                _canvasGroup.blocksRaycasts = true;
            }
        }
    }
}