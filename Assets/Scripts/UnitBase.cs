using UnityEngine;
using UnityEngine.AI;

public abstract class UnitBase : MonoBehaviour, IDamgeable
{
    public StateMachine stateMachine { get; private set; }

    public NavMeshAgent Agent { get; protected set; }
    public Animator Animator { get; protected set; }

    public Transform Target { get; protected set; }

    [Header("Stat")]
    protected UnitStatSO statSO;
    public UnitStat unitStat;
    public float CurrentHealth { get; protected set; }

    public IdleState IdleState { get; private set; }
    public ChasingState ChasingState { get; private set; }
    public AttackState AttackState { get; private set; }

    protected virtual void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();

        stateMachine = new StateMachine();
        IdleState = new IdleState(this);
        ChasingState = new ChasingState(this);
        AttackState = new AttackState(this);
    }

    protected virtual void Start()
    {
        CurrentHealth = unitStat.maxHealth;
        Agent.speed = unitStat.moveSpeed;

        stateMachine.ChangeState(IdleState);
    }

    protected virtual void Update()
    {
        stateMachine.Update();
    }

    public bool IsTargetInRange(float range)
    {
        if (Target != null)
        {
            return Vector3.Distance(transform.position, Target.position) <= range;
        }

        return false;
    }

    public void LookAtTarget()
    {
        if (Target != null)
        {
            Vector3 direction = (Target.position - transform.position).normalized;
            transform.forward = new Vector3(direction.x, 0f, direction.z);
        }
    }

    public virtual void Attack()
    {
        Debug.Log($"{name}: 의 공격!");
    }

    public virtual void TakeDamage(float damage)
    {
        float finalDamage = damage - unitStat.defense <= 0 ? 1 : damage - unitStat.defense;
        CurrentHealth -= finalDamage;

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"{name} 죽음.");

        Destroy(gameObject);
    }
}