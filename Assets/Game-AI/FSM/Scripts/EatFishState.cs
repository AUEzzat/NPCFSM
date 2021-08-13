using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFishState : FSMState<Fisher>
{
    Transform player;
    float countDown = 5;
    Home home;

    public EatFishState(Transform player, Home home)
    {
        this.player = player;
        this.home = home;
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
        home.OpenDoor();
        owner.StartCoroutine(CloseDoor());
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(5);
        home.CloseDoor();
    }

    public override void Update()
    {
        if(owner.fishCount > 0)
        {
            if (countDown < 0)
            {
                animator.SetTrigger("Eat");
                owner.fishCount--;
                countDown = 5;
            }
            else
            {
                countDown -= Time.deltaTime;
            }
        }
        else
        {
            fsm.ChangeState(owner.catchFish);
        }

        if(Vector3.Distance(player.position, owner.transform.position) < 5)
        {
            fsm.ChangeState(owner.throwBoulder);
        }
    }
}
