using Resources;
using Saver;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BlockUi : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private UnityEvent onBuy;
    private SaveManager _saveManager;
    private TextMeshProUGUI _priceText;
    private GameObject blockbuiSound;
    

    private void Awake()
    {    
        blockbuiSound = GameObject.Find("BlockBuiSound");
        _saveManager = FindObjectOfType<SaveManager>();
        _priceText = GetComponent<TextMeshProUGUI>();
        ShowPrice();
    }
         
    public void BuyBlock()
    {
            var affordableAmount = Mathf.Min(ResourcesData.MoneyCount, price);
            ResourcesData.MoneyCount -= affordableAmount;
            price -= affordableAmount;
            ShowPrice();
            _saveManager.SaveAll();
            if (price == 0)
            {
                Debug.Log("YOU BUY");
                onBuy?.Invoke();
                _saveManager.SaveAll();
                blockbuiSound.GetComponent<AudioSource>().Play();
            }
    }

    private void ShowPrice()
    {
        _priceText.text = price.ToString();
    }
}