using Resources;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIGameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI phoneText;
        [SerializeField] private TextMeshProUGUI moneyCount;
        [SerializeField] private TextMeshProUGUI compResources;
        [SerializeField] private TextMeshProUGUI tvResources;
    
        private void Awake()
        {
            ShowResources();
        }

        public void ShowResources()
        {
            phoneText.text = ResourcesData.PhoneCount.ToString();
            moneyCount.text = ResourcesData.MoneyCount.ToString();
            compResources.text = ResourcesData.CompCount.ToString();
            tvResources.text = ResourcesData.TVCount.ToString();
        }

        private void FixedUpdate()
        {
            ShowResources();
        }
    }
}
