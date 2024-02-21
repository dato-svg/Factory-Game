using UnityEngine;
using UnityEngine.InputSystem;

namespace Controller
{
    [RequireComponent(typeof(PlayerController))]
    public class HeroReader : MonoBehaviour
    {
         private PlayerController _playerController;


         private void Awake()
         {
             _playerController = GetComponent<PlayerController>();
         }

         public void OnMove(InputAction.CallbackContext value)
         {
            Vector2 move = value.ReadValue<Vector2>();
            _playerController.OnDirection(move);
            
            _playerController.SetWalkingAnimation(move != Vector2.zero);

            if (move != Vector2.zero)
            {
                _playerController.TakePhone(false);
            }
            
         }
    
    }
}
