using System.Collections;
using Resources;
using Saver;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.Events;

public class BlockUi : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private UnityEvent onBuy;
    private SaveManager _saveManager;
    private TextMeshProUGUI _priceText;
    private GameObject blockbuiSound;
    private UIGameManager _playerPrice;
    private float speed = 4;
    
    private void Awake()
    {
        _playerPrice = FindObjectOfType<UIGameManager>();
        blockbuiSound = GameObject.Find("BlockBuiSound");
        _saveManager = FindObjectOfType<SaveManager>();
        _priceText = GetComponent<TextMeshProUGUI>();
        ShowPrice();
    }
         
    public void BuyBlock()
    {
        if (ResourcesData.MoneyCount > price )
        {    
            Debug.Log("YOU TryBuy");

             StartCoroutine(ReducePriceCoroutine());
        }

        if (ResourcesData.MoneyCount < price)
        {
            _playerPrice.moneyCount.color = new Color(198f / 255f, 33f / 255f, 33f / 255f);
            GetComponent<TextMeshProUGUI>().color = new Color(198f / 255f, 33f / 255f, 33f / 255f);
        }
    }

    public void ExitBlock()
    {
        _playerPrice.moneyCount.color = new Color(0,0,0);
        GetComponent<TextMeshProUGUI>().color = new Color(0,0,0);
    }
    private void ShowPrice()
    {
        _priceText.text = price.ToString();
    }

   
    
    
    private IEnumerator ReducePriceCoroutine()
    {
        var startPrice = price;
        int canBuy= 20;   
        while (price > 0)
        { 
           
            float currentPrice = (float)price;
            
          
            currentPrice = Mathf.Lerp(currentPrice, 0, speed * Time.deltaTime);
            price = Mathf.RoundToInt(currentPrice);
            ShowPrice(); 
          
            if (price < canBuy)  
            {
                Debug.Log("YOU BUY");
                onBuy?.Invoke();
                ResourcesData.MoneyCount -= startPrice;
                _playerPrice.ShowResources();
                _saveManager.SaveAll();
                blockbuiSound.GetComponent<AudioSource>().Play();
            }
            yield return null;
        }
    }
}