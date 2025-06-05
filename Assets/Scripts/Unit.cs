using UnityEngine;
using UnityEngine.AI;

public abstract class Unit : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }

    public NavMeshAgent Agent { get; protected set; }
    public Animator Animator { get; protected set; }

    public Transform Target { get; set; }

    public abstract UnitStatSO Stats { get; }
    public abstract float CurrentHealth { get; }

    protected IdleState idleState;

    protected virtual void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();

        stateMachine = new StateMachine();
    }

    protected virtual void Start()
    {
        stateMachine.ChangeState(idleState);
    }
}
