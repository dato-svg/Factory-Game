using UnityEngine;

namespace Components
{
    public class CameraFollowComponent : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private  float speed;
        [SerializeField] private Vector3 distance;

        private void LateUpdate()
        {
            var targetPosition = target.position + distance;
            var deps = Vector3.Lerp(transform.position, targetPosition,
                Time.deltaTime * speed);
            transform.position = deps;
            
        }
    }
}
