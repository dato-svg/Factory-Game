using UnityEngine;

public class CubeController : MonoBehaviour
{
     private GameObject target;
    [SerializeField] private float speed;

    private void Start()
    {
        target = GameObject.Find("Player");
    }
    
    
    private void Update()
    {
        
        if (target != null)
        {
           
            Vector3 direction = (target.transform.position - transform.position).normalized;

           
            Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

            
            transform.position = newPosition;
            if (Vector3.Distance(transform.position,target.transform.position) <= 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
