using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFishState : FSMState<Fisher>
{
    Home home;
    Transform target;

    public CatchFishState(Home home)
    {
        this.home = home;
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        if (owner.fishCount < 10)
        {
            if (target == null)
            {
                target = Flock.Instance.GetRandomFish();
            }
            else
            {
                agent.SetDestination(target.position);
                if (Vector3.Distance(target.position, owner.transform.position) < agent.stoppingDistance)
                {
                    owner.fishCount++;
                    animator.SetTrigger("Fish");
                    target = null;
                }
            }
        }
        else
        {
            fsm.ChangeState(owner.returnHome);
        }
        
    }
}
