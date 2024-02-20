using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerResources : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private int countPrefabs;
    private readonly List<GameObject>  _spawnedObjects = new List<GameObject>(); 
    private float speed = 20;

    [ContextMenu("SpawnResources")]
    public void SpawnResources()
    {
        StartCoroutine(SpawnObjectsWithDelay());
    }

    private IEnumerator SpawnObjectsWithDelay()
    {
        for (int i = 0; i < countPrefabs; i++)
        {
           GameObject newObject = Instantiate(prefab, spawnPosition.position, Quaternion.identity);
           _spawnedObjects.Add(newObject);
           yield return new WaitForSeconds(0.1f);
        }
    }

    private void Update()
    {
        foreach (var spawnedObject  in _spawnedObjects)
        {
            if (spawnedObject != null)
            {
                spawnedObject.transform.position = Vector3.MoveTowards(spawnedObject.transform.position,
                    transform.position, speed * Time.deltaTime);
                if (Vector3.Distance(spawnedObject.transform.position,transform.position) < 0.5f)
                {
                    Destroy(spawnedObject);
                }
                
            }
        }
        
    }
}