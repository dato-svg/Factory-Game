using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    [SerializeField] private GameObject particles;

    private GameObject _canvas;

    private void Awake()
    {
        _canvas = GameObject.Find("UICanvas");
    }


    public void Spawn()
    {
        GameObject particle = Instantiate(particles, transform.position, Quaternion.identity);
        particle.transform.SetParent(_canvas.transform);
        particle.transform.SetAsLastSibling();
        Destroy(particle.gameObject,2f);
    }
        
}
