using UnityEngine;

namespace Components
{
    public class MenuAnimationController : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int OffMenu = Animator.StringToHash("OffMenu");


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void CloseWindow()
        {
            _animator.SetTrigger(OffMenu);
        }
    }
}
