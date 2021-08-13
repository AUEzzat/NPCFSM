using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohesion : MonoBehaviour, ISteer
{
    [HideInInspector]
    public Flock flock;

    public Vector3 GetForce()
    {
        if (flock == null)
            flock = GetComponentInParent<Flock>();

        Vector3 force = Vector3.zero;

        List<Transform> flockList = flock.GetFlock(gameObject);
        int flockCount = 0;

        foreach (Transform child in flockList)
        {
            if (Vector3.Distance(transform.position, child.position) < 5)
            {
                force += child.position;
                flockCount++;
            }
        }

        if (flockCount > 0)
        {
            force /= flockCount;
            force -= transform.position;
        }

        return force.normalized * flock.cohesionWeight;
    }
}
