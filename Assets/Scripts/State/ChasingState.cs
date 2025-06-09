public class ChasingState : IState
{
    private UnitBase unit;

    public ChasingState(UnitBase unit)
    {
        this.unit = unit;
    }

    public void Enter()
    {
        // 뛰는 애니메이션
        unit.Animator.Play("Run");
    }

    public void Exit()
    {
        unit.Agent.ResetPath();
    }

    public void Update()
    {
        if (unit.Target == null)
        {
            unit.stateMachine.ChangeState(unit.IdleState);
            return;
        }

        unit.Agent.SetDestination(unit.Target.position);

        if (unit.IsTargetInRange(unit.unitStat.attackRange))
        {
            unit.stateMachine.ChangeState(unit.AttackState);
        }
    }
}
