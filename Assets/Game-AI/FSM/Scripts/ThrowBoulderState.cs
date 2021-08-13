using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBoulderState : FSMState<Fisher>
{
    Transform player;

    public ThrowBoulderState(Transform player)
    {
        this.player = player;
    }


    public override void Enter()
    {

    }

    public override void Exit()
    {
        animator.SetFloat("Direction", 0);
        animator.SetBool("Shoot", false);
    }

    public override void Update()
    {
        Vector3 dir = player.position - owner.transform.position;
        float angle = Vector3.Angle(owner.transform.forward, dir.normalized);
        if (angle > 30)
        {
            owner.transform.rotation = Quaternion.Lerp(owner.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10);
            animator.SetFloat("Direction", angle);
        }
        else
        {
            animator.SetBool("Shoot", true);
        }

        if (Vector3.Distance(player.position, owner.transform.position) > 6)
        {
            fsm.RevertToPreviousState();
        }
    }
}
