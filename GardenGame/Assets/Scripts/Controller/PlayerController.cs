using UnityEngine;

namespace Controller
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {    
         [SerializeField] [Range(0,400)] [Header("Parameters")] private float speed;
         
         private const float LEFT_ROTATION = -90f;
         private const float RIGHT_ROTATION = 90f;
         private const float DOWN_ROTATION = 180f;
         private const float DOWN_LEFT = -130f;
         private const float DOWN_RIGHT = -220f;
         private const float UP_LEFT = -400F;
         private const float RIGHT_UP = -310f;
         
         private Rigidbody _rigidbody;
         private Vector2 _direction;
         private Vector2 _rotateDirection;
         private Animator _animator;
         private static readonly int IsWork = Animator.StringToHash("isWork");
         private static readonly int IsWalk = Animator.StringToHash("isWalk");
         
         

         private void Awake()
         {
             _rigidbody = GetComponent<Rigidbody>();
             _animator = GetComponentInChildren<Animator>();
             
         }

         public void TakePhone(bool attack)
         {
             _animator.SetBool(IsWork,attack);

         }
         

        private void OnRotate()
        {    
            var rotation = transform.rotation;
            
            
            if (_rotateDirection.x < 0)
            {
                rotation = Quaternion.Euler(rotation.x,LEFT_ROTATION,rotation.z);
                transform.rotation = rotation;
            }
            if (_rotateDirection.x > 0)
            {
                rotation = Quaternion.Euler(rotation.x,RIGHT_ROTATION,rotation.z);
                transform.rotation = rotation; 
            }
            if (_rotateDirection.y < 0)
            {
                rotation = Quaternion.Euler(rotation.x,DOWN_ROTATION,rotation.z);
                transform.rotation = rotation;
            }
            if (_rotateDirection.y > 0)
            {
                rotation = Quaternion.Euler(rotation.x,0,rotation.z);
                transform.rotation = rotation;
            }

            if (_rotateDirection.x < 0 && _rotateDirection.y < 0)
            {
                rotation = Quaternion.Euler(rotation.x,DOWN_LEFT,rotation.z);
                transform.rotation = rotation;
            }
            
            
            if (_rotateDirection.x > 0 && _rotateDirection.y < 0)
            {
                rotation = Quaternion.Euler(rotation.x,DOWN_RIGHT,rotation.z);
                transform.rotation = rotation;
            }
            
            if (_rotateDirection.x < 0 && _rotateDirection.y > 0)
            {
                rotation = Quaternion.Euler(rotation.x,UP_LEFT,rotation.z);
                transform.rotation = rotation;
            }
            
            if (_rotateDirection.x > 0 && _rotateDirection.y > 0)
            {
                rotation = Quaternion.Euler(rotation.x,RIGHT_UP,rotation.z);
                transform.rotation = rotation;
            }
            
        }
        private void Movement()
        {
            var xDirection = _direction.x * speed * Time.fixedDeltaTime;
            var yDirection = _direction.y * speed * Time.fixedDeltaTime;
            _rigidbody.velocity = new Vector3(xDirection, _rigidbody.velocity.y, yDirection);
        }



        private void FixedUpdate()
        {
            OnRotate();
            Movement();
        }
        
        
        public void OnDirection(Vector2 direction)
        {
            this._direction = direction;
            this._rotateDirection = direction;
            
        }
        
        public void SetWalkingAnimation(bool isWalking)
        {
            _animator.SetBool(IsWalk, isWalking);
        }
    }
}
