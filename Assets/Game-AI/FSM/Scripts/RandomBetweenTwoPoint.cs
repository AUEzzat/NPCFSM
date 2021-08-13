using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomBetweenTwoPoint : MonoBehaviour
{
    [SerializeField]
    List<Transform> points;

    int pointIndex = 0;

    NavMeshAgent agent;
    Animator animator;
    Home home;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        home = Singleton<Home>.Instance;
        home.DoorOpened.AddListener(OnDoorOpened);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);

        Vector3 dir = transform.position - points[pointIndex].position;
        dir.y = 0;

        if (dir.magnitude < agent.stoppingDistance)
        {
            if (Vector3.Angle(transform.forward, dir) > 10)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime);
        }
    }

    void OnDoorOpened()
    {
        agent.SetDestination(points[pointIndex = (pointIndex + 1) % points.Count].position);
    }
}
