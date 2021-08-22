using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Profiling;

public class ProfileDemo1 : MonoBehaviour
{
    [SerializeField] int NumThingsToSpawn = 1000;
    [SerializeField] float SpawnDelay = 5f;
    [SerializeField] float SpawnDistance = 50f;
    [SerializeField] GameObject PrefabToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    static readonly ProfilerMarker SpawnLoop = new ProfilerMarker("Spawn Loop");

    // Update is called once per frame
    void Update()
    {
        if (SpawnDelay >= 0)
        {
            SpawnDelay -= Time.deltaTime;
            if (SpawnDelay > 0)
                return;
        }

        using(SpawnLoop.Auto())
        {
            for (int count = 0; count < NumThingsToSpawn; ++count)
            {
                Vector3 offset = new Vector3(Random.Range(-SpawnDistance, SpawnDistance),
                                             Random.Range(-SpawnDistance, SpawnDistance),
                                             Random.Range(-SpawnDistance, SpawnDistance));
                var newObject = Instantiate(PrefabToSpawn);
                newObject.transform.position = transform.position + offset;
            }
        }
    }
}
