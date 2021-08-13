using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour, ISteer
{
    [HideInInspector]
    public Transform target;
    [SerializeField]
    float speed = 1;
    public virtual Vector3 GetForce()
    {
        Vector3 dir = target.position - transform.position;

        Vector3 velocity = dir.normalized * speed;

        if (dir.magnitude < 5)
            velocity *= dir.magnitude / 5;

        return velocity;
    }
}
