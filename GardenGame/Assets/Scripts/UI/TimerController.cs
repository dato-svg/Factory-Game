using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private UnityEvent onTimeOver;
        [SerializeField] private CoolDown coolDown;
        private Image _image;

        private void Awake()
        {
            _image = transform.Find("Image").GetComponent<Image>();
        }

    

        public void ActiveCoroutine()
        {
            StartCoroutine(RunTimer());
        }

        private IEnumerator RunTimer()
        {
            coolDown.Reset(); 
            float startTime = Time.time;

            while (!coolDown.IsReady)
            {
                float elapsed = Time.time - startTime;
                float progress = elapsed / coolDown.Timer;
                _image.fillAmount = Mathf.Lerp(0f, 1f, progress);
                yield return null; 
            }

        
            onTimeOver?.Invoke(); 
        }
    }
}