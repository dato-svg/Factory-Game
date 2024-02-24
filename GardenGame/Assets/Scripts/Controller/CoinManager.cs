using System.Collections;
using Resources;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{ 
    
   [SerializeField] private GameObject _Coin;
   [SerializeField] private string name;

   private Coroutine _coroutine;
   public Transform[] childTransforms;
   

   private void FixedUpdate()
   {
       if (_Coin == null)
       {
           _Coin = GameObject.Find(name);
           _Coin.SetActive(false);
           ImageActivate(false);


       }
       
   }

   private void ImageActivate(bool isActive)
   {
       childTransforms = new Transform[_Coin.transform.childCount];
       for (int i = 0; i < _Coin.transform.childCount; i++)
       {
           childTransforms[i] = _Coin.transform.GetChild(i);
           childTransforms[i].GetComponent<Image>().enabled = isActive;
       }
   }
   
   
   
    public void CheckResourcesPhoneStart()
    {    
         StartCoroutine(CheckResourcesPhone());
    }

    
    public void CheckResourcesCompStart()
    {
        StartCoroutine(CheckResourcesComp());
    }

    
    
    public void CheckResourcesTVStart()
    {
        StartCoroutine(CheckResourcesTv());
    }

    
    
    private IEnumerator CheckResourcesPhone()
    {
        if (ResourcesData.PhoneCount > 0)
        {
            _Coin.SetActive(true);
            ImageActivate(true);
            yield return new WaitForSeconds(1.1f);
            ImageActivate(false);
            _Coin.SetActive(false);
        }
    }
    
    
    private IEnumerator CheckResourcesComp()
    {
        if (ResourcesData.CompCount > 0)
        {
            _Coin.SetActive(true);
            ImageActivate(true);
            yield return new WaitForSeconds(1.1f);
            ImageActivate(false);
            _Coin.SetActive(false);
        }
    }
    
    
    private IEnumerator CheckResourcesTv()
    {
        if (ResourcesData.TVCount > 0)
        {
            _Coin.SetActive(true);
            ImageActivate(true);
            yield return new WaitForSeconds(1.1f);
            ImageActivate(false);
            _Coin.SetActive(false);
        }
    }
}
