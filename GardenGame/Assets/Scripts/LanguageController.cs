using UnityEngine;

public class LanguageController : MonoBehaviour
{
    [SerializeField] private GameObject _language;
    private bool isActive = false;
    
    public void LanguageChange()
    {
        if (!isActive)
        {
            _language.SetActive(true);
            isActive = true;
        }
        else
        {
            _language.SetActive(false);
            isActive = false;
        }
            
    }
        
}

