using System.Collections;
using Resources;
using UnityEngine;

public class CoinManager : MonoBehaviour
{ 
    
   [SerializeField]  private GameObject _Coin;
   [SerializeField] private string name;

   private Coroutine _coroutine;
    
    private void Start()
    {
        
       
    }

    private void FixedUpdate()
    {
        if (_Coin == null)
        {
            _Coin = GameObject.Find(name);
            _Coin.SetActive(false);
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
            yield return new WaitForSeconds(1.1f);
            _Coin.SetActive(false);
        }
    }
    
    
    private IEnumerator CheckResourcesComp()
    {
        if (ResourcesData.CompCount > 0)
        {
            _Coin.SetActive(true);
            yield return new WaitForSeconds(1.1f);
            _Coin.SetActive(false);
        }
    }
    
    
    private IEnumerator CheckResourcesTv()
    {
        if (ResourcesData.TVCount > 0)
        {
            _Coin.SetActive(true);
            yield return new WaitForSeconds(1.1f);
            _Coin.SetActive(false);
        }
    }
}
