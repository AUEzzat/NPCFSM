using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Home : MonoBehaviour
{
    Animator animator;
    public UnityEvent DoorOpened;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void CloseDoor()
    {
        animator.SetTrigger("close_door");
    }

    public void OpenDoor()
    {
        animator.SetTrigger("open_door");
        DoorOpened.Invoke();
    }
}
