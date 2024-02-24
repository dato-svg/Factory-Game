    using System;
    using UI;
    using UnityEngine;

    namespace Resources
    {
        public class ResourcesTake : MonoBehaviour
        {
            [SerializeField] private int giveMoneyCount;
            [SerializeField] private UIFactory uiFactory;
            private UIGameManager _uiGameManager;

            private void Awake()
            {
                _uiGameManager = FindObjectOfType<UIGameManager>();
            }
            
            
            public void BuffPhone()
            {
                if (ResourcesData.MoneyCount >= uiFactory.UpdatePrice)
                {
                    ResourcesData.MoneyCount -= uiFactory.UpdatePrice;
                    uiFactory.UpdatePrice *= 2;
                    ResourcesData.PhoneBuffer *= 2;
                    uiFactory.ShowPrice();
                    _uiGameManager.ShowResources();
                    Debug.Log(ResourcesData.PhoneBuffer);
                }
               
            }
            
            public void BuffComp()
            {
                if (ResourcesData.MoneyCount >= uiFactory.UpdatePrice)
                {
                    ResourcesData.MoneyCount -= uiFactory.UpdatePrice;
                    uiFactory.UpdatePrice *= 2;
                    ResourcesData.CompBuffer *=2;
                    uiFactory.ShowPrice();
                    _uiGameManager.ShowResources();
                    Debug.Log(ResourcesData.CompBuffer);
                }
               
            }

            public void BuffTV()
            {
                if (ResourcesData.MoneyCount >= uiFactory.UpdatePrice)
                {
                    ResourcesData.MoneyCount -= uiFactory.UpdatePrice;
                    uiFactory.UpdatePrice *= 2;
                    ResourcesData.TVBuffer *= 2;
                    uiFactory.ShowPrice();
                    _uiGameManager.ShowResources();
                    Debug.Log(ResourcesData.TVBuffer); 
                }
                
            }

            
            public void TakePhoneResources()
            {
                var phoneBuffer = ResourcesData.PhoneCount * ResourcesData.PhoneBuffer;
                TakeResources( phoneBuffer , ref ResourcesData.PhoneCount);
                Debug.Log(ResourcesData.PhoneBuffer +"ResourcesData.PhoneBuffer");
            }
        
        
            public void TakeCompResources()
            {
                var compBuffer = ResourcesData.CompCount * ResourcesData.CompBuffer;
                TakeResources( compBuffer, ref ResourcesData.CompCount);
            }
        
            public void TakeTvResources()
            {
                var tvBuffer = ResourcesData.TVCount * ResourcesData.TVBuffer;
                TakeResources( tvBuffer, ref ResourcesData.TVCount);
            }

            private void TakeResources( int resources, ref int resourcesZero)
            {
                ResourcesData.MoneyCount += resources;
                resourcesZero = 0;
                
                _uiGameManager.ShowResources();
            }
        
            public void GiveMoney()
            {
                ResourcesData.MoneyCount += giveMoneyCount;
                _uiGameManager.ShowResources();
            }


            
            

        }
    }
