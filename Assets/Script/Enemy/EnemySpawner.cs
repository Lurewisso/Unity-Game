using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    int count = 5;
    public List<Transform> spawnPoints;

    int minCount = 10;
    int maxCount = 100;


    void Start()
    {
        count = Random.Range(minCount, maxCount);

        for (int i = 0; i < count; i++)
        {
            var rndPoint = Random.Range(0, spawnPoints.Count);
            SpawnEnemies(spawnPoints[rndPoint]);
        }
    }

   
    void Update()
    {
        
    }

    void SpawnEnemies(Transform point)
    {
        Instantiate(enemy, GetRandomInradius(point.position,3), Quaternion.identity);
    }

    public Vector2 GetRandomInradius(Vector3 centerPoint, float radius)
    {
        return centerPoint + (Random.insideUnitSphere * radius);
    }


}
