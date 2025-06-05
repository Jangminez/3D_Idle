public class StateMachine
{
    Unit unit;
    IState currentState;

    public IdleState IdleState { get; private set; }

    public void Init(Unit unit)
    {
        this.unit = unit;

        IdleState = new IdleState(unit);
        
        ChangeState(IdleState);
    }

    public void ChangeState(IState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }

    public void Update()
    {
        currentState?.Update();
    }
}
