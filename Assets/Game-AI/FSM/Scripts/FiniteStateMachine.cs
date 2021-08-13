using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FiniteStateMachine<T>
{
    public T owner { get; private set; }

    FSMState<T> previousState;
    FSMState<T> currentState;

    public Animator animator { get; private set; }
    public NavMeshAgent agent { get; private set; }

    public FiniteStateMachine(T owner, FSMState<T> initialState, Animator animator, NavMeshAgent agent)
    {
        this.owner = owner;
        this.animator = animator;
        this.agent = agent;

        currentState = initialState;
    }

    public void Update()
    {
        currentState.Update();
    }

    public void ChangeState(FSMState<T> newState)
    {
        previousState = currentState;
        if (currentState != null)
            currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void RevertToPreviousState()
    {
        if (previousState != null)
            ChangeState(previousState);
    }
}
