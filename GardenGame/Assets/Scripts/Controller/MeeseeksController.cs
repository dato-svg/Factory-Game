using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Controller
{
    public class MeeseeksController : MonoBehaviour
    {
        [SerializeField] private GameObject[] meeseeks;
        [SerializeField] private Sprite[] meeseksSprite;
        [SerializeField] private AudioClip[] dieMeeseksSound;
        [SerializeField] private AudioClip[] enableMeeseksSound;
        [SerializeField] private float delaySpawn = 5;
    
        private AudioSource _audioSource;
        private int _randomIndex;
        private int _randomIndexSprite;

        private bool _isMeeseksActive = false;


        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void ActiveMeeseks()
        {
            StartCoroutine(MeeseksEnable());
        }

        public void MeeseksDisable()
        {
            _audioSource.PlayOneShot(dieMeeseksSound[0]);
            _audioSource.PlayOneShot(dieMeeseksSound[1]);
        
        
            if (_isMeeseksActive)
            {
          
                foreach (var meeseek in meeseeks)
                {
                    meeseek.SetActive(false);
                }

           
                _isMeeseksActive = false;
            }
        }

   

        private IEnumerator MeeseksEnable()
        {    
            yield return new WaitForSeconds(delaySpawn);
            while (true)
            {
                int randomIndex = Random.Range(0, meeseeks.Length);
                meeseeks[randomIndex].GetComponentInChildren<Image>().sprite = GetRandomSprite();
                Debug.Log($"Random Index: {randomIndex}, Sprite: {meeseksSprite[_randomIndexSprite]}");
                meeseeks[randomIndex].SetActive(true);

            
                _isMeeseksActive = true;
                _audioSource.PlayOneShot(enableMeeseksSound[Random.Range(0,enableMeeseksSound.Length)]);
                Debug.Log(enableMeeseksSound[Random.Range(0,enableMeeseksSound.Length)]);
                yield return new WaitForSeconds(delaySpawn);
                meeseeks[randomIndex].SetActive(false);
            }
    
        }
    
        private Sprite GetRandomSprite()
        {
            _randomIndexSprite = Random.Range(0, meeseksSprite.Length);
            return meeseksSprite[_randomIndexSprite];
        }
    
    }
}