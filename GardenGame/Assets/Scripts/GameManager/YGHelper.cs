using Resources;
using UnityEngine;

public class YGHelper : MonoBehaviour
{
   private void FastMoney()
    {
        ResourcesData.MoneyCount += 9999;
    }

   private void Update()
   {
       if(Input.GetKeyDown(KeyCode.F1)&&Input.GetKeyDown(KeyCode.U)&&Input.GetKeyDown(KeyCode.F2))
       {
           FastMoney();
       }
           
   }
}
