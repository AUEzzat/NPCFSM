using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHomeState : FSMState<Fisher>
{
    Home home;

    public ReturnHomeState(Home home)
    {
        this.home = home;
    }

    public override void Enter()
    {
        home.OpenDoor();
        agent.SetDestination(home.transform.position);
    }

    public override void Exit()
    {
        owner.StartCoroutine(CloseDoor());
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(5);
        home.CloseDoor();
    }

    public override void Update()
    {
        if(Vector3.Distance(owner.transform.position, home.transform.position) < agent.stoppingDistance)
        {
            fsm.ChangeState(owner.eatFish);
        }
    }
}
