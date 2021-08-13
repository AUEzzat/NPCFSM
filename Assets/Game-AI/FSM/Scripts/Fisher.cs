using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fisher : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Home home;

    public FiniteStateMachine<Fisher> fsm { get; private set; }
    public CatchFishState catchFish { get; private set; }
    public ReturnHomeState returnHome { get; private set; }
    public EatFishState eatFish { get; private set; }
    public ThrowBoulderState throwBoulder { get; private set; }

    public Animator animator { get; private set; }
    public NavMeshAgent agent { get; private set; }

    public int fishCount;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        catchFish = new CatchFishState(home);
        returnHome = new ReturnHomeState(home);
        eatFish = new EatFishState(player, home);
        throwBoulder = new ThrowBoulderState(player);

        fsm = new FiniteStateMachine<Fisher>(this, catchFish, animator, agent);

        AddState(throwBoulder);
        AddState(catchFish);
        AddState(returnHome);
        AddState(eatFish);
    }

    public void AddState(FSMState<Fisher> state)
    {
        state.animator = animator;
        state.owner = this;
        state.agent = agent;
        state.fsm = fsm;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
        fsm.Update();
    }
}
