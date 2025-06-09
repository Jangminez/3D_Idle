using UnityEngine;

public class AttackState : IState
{
    private UnitBase unit;

    private float attackCooldown;
    private float lastAttackTime;

    public AttackState(UnitBase unit)
    {
        this.unit = unit;
    }

    public void Enter()
    {
        unit.Agent.isStopped = true;
        attackCooldown = 1 / unit.unitStat.attackSpeed;
        lastAttackTime = -attackCooldown;
        
        // 공격 애니메이션
        unit.Animator.SetFloat("AttackSpeed", unit.unitStat.attackSpeed);
        unit.Animator.Play("Attack");
    }

    public void Exit()
    {
        unit.Agent.isStopped = false;
    }

    public void Update()
    {
        if (unit.Target == null || !unit.IsTargetInRange(unit.unitStat.attackRange))
        {
            unit.stateMachine.ChangeState(unit.IdleState);
            return;
        }

        unit.LookAtTarget();

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            unit.Attack();
            lastAttackTime = Time.time;
        }
    }
}
