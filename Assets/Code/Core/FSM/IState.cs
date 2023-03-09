namespace GameLib.Core.FSM
{
    public interface IState
    {
        int ID { get; }
        FiniteStateMachine FSM { get; set; }
        bool Enter(object data);
        bool Exit();
        bool Update(float dt);
        bool TryTransTo(int id);
    }
}
