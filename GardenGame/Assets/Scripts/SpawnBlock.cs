using System.Collections;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    
    [SerializeField] private GameObject SpawnObject;
    [SerializeField] private float SpawnDelay;

    private Coroutine spawnCoroutine;
    
    
    public void StartSpawnCube()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnCube());
        }
    }
    
    public void StopSpawnCube()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }
    
    private IEnumerator SpawnCube()
    {
        while (true)
        {
            yield return  new WaitForSeconds(SpawnDelay);
            GameObject g = Instantiate(SpawnObject,transform.position,Quaternion.identity);
        }
        
    }
}
