using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject Boss;

    int count = 5;
    public List<Transform> spawnPoints;

    int minCount = 1;
    int maxCount = 10;

    public static int CountOfZombi;


    

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
        if (CountOfZombi >= count)
        {
            Instantiate(Boss,transform.position, Quaternion.identity);
            CountOfZombi = 0;
        }
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
