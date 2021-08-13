using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : Singleton<Flock>
{
    public float cohesionWeight;
    public float seperationWeight;
    public float alignmentWeight;

    [SerializeField]
    int fishCount = 30;
    [SerializeField]
    Vector3 tankLimits = new Vector3(5, 0, 5);
    [SerializeField]
    Transform target;

    [SerializeField]
    GameObject[] fish;

    GameObject[] fishInstances;

    private void Awake()
    {
        fishInstances = new GameObject[fishCount];
        for (int i = 0; i < fishCount; i++)
        {
            GameObject fishInstance = Instantiate(fish[Random.Range(0, fish.Length)], transform);
            SetRandomLocation(fishInstance.transform);
            fishInstance.AddComponent<Seek>().target = target;
            fishInstances[i] = fishInstance;
        }
    }

    void SetRandomLocation(Transform fishTrans)
    {
        fishTrans.position = transform.position + new Vector3(Random.Range(-tankLimits.x, tankLimits.x),
                Random.Range(-tankLimits.y, tankLimits.y),
                Random.Range(-tankLimits.z, tankLimits.z));
    }

    public Transform GetRandomFish()
    {
        GameObject fish = fishInstances[Random.Range(0, fishInstances.Length)];
        return fish.transform;
    }

    public List<Transform> GetFlock(GameObject other)
    {
        List<Transform> flock = new List<Transform>();

        foreach (Transform child in transform)
        {
            if (other != child.gameObject)
                flock.Add(child);
        }

        return flock;
    }
}
