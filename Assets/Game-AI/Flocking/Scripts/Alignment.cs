using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignment : MonoBehaviour, ISteer
{
    [HideInInspector]
    public Flock flock;

    public Vector3 GetForce()
    {
        if (flock == null)
            flock = GetComponentInParent<Flock>();

        Vector3 force = Vector3.zero;

        List<Transform> flockList = flock.GetFlock(gameObject);

        foreach(Transform child in flockList)
        {
            force += child.forward;
        }

        force /= flockList.Count;

        return force * flock.alignmentWeight;
    }
}
