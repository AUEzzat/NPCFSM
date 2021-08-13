using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class FSMState<T>
{
    public FiniteStateMachine<T> fsm;
    public T owner;
    public Animator animator;
    public NavMeshAgent agent;

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
