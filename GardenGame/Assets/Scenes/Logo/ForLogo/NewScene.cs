using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource),typeof(Image))]
public class NewScene : MonoBehaviour
{
     
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private float delay = 0.08f;
    private AudioSource audio;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        
        StartCoroutine(WaitFrame());
        
    }

    private IEnumerator WaitFrame()
    {    
        audio.Play();
        foreach (var t in sprite)
        {
            yield return new WaitForSeconds(delay);
            image.sprite = t;
        }

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainScene");
    }
    
    
    
}
