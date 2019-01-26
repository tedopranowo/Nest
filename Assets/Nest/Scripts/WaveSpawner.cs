using System.Collections;
using UnityEngine;

[System.Serializable]
public struct SpawnData
{
    [Tooltip("Object to spawn")]
    public GameObject prefab;

    [Tooltip("How long after the start of the game the first object will be spawned")]
    public float delayedStart;

    [Tooltip("The minimum duration of spawn interval")]
    public float minSpawnInterval;

    [Tooltip("The maximum duration of spawn interval")]
    public float maxSpawnInterval;

    [Tooltip("The center of the circle for random spawning")]
    public Vector3Reference center;

    [Tooltip("The minimum distance from center the object will be spawned")]
    public float minRadius;
    
    [Tooltip("The maximum distance from center the object will be spawned")]
    public float maxRadius;

    [Tooltip("The amount of objects that will be spawned")]
    public int amount;
}

public class WaveSpawner : MonoBehaviour {

    [SerializeField] private SpawnData[] m_spawnData;

    /// <summary>
    /// Spawn the object every certain random interval
    /// </summary>
    private IEnumerator SpawnCoroutine(SpawnData spawnData)
    {
        yield return new WaitForSeconds(spawnData.delayedStart);

        while(true)
        {
            //SPawn the object
            SpawnObject(ref spawnData);

            //Wait for random interval
            float waitTime = Random.Range(spawnData.minSpawnInterval, spawnData.maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);
        }
    }

    /// <summary>
    /// Spawn the object(s) specified by SpawnData
    /// </summary>
    public void SpawnObject(ref SpawnData spawnData)
    {
        for(int i=0; i<spawnData.amount; ++i)
        {
            //Choose spawn location
            float randomRadius = Random.Range(spawnData.minRadius, spawnData.maxRadius);
            Vector2 randomSpawnPositionFromCenter = Random.insideUnitCircle.normalized * randomRadius;
            Vector3 spawnLocation = spawnData.center 
                + new Vector3(randomSpawnPositionFromCenter.x, randomSpawnPositionFromCenter.y);

            //Spawn the object
            Instantiate(spawnData.prefab, spawnLocation, Quaternion.identity);
        }
    }

    private void Start()
    {
        //Start spawning object coroutines
        for (int i=0; i<m_spawnData.Length; ++i)
        {
            StartCoroutine(SpawnCoroutine(m_spawnData[i]));
        }
    }
}
