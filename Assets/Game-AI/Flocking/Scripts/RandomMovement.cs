using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour, ISteer
{
    Vector3 velocity = Vector3.zero;

    public Vector3 GetForce()
    {
        if (Random.Range(0, 10) < 1)
            velocity = transform.forward * Random.Range(1, 2);
        else if (velocity.magnitude > 0)
            velocity -= velocity.normalized * 0.01f;

        return velocity;
    }
}
