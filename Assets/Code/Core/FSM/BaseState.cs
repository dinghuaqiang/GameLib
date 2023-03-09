namespace GameLib.Core.FSM
{
    public abstract class BaseState : IState
    {
        public int ID { get { return OnStateID(); } }

        public FiniteStateMachine FSM { get; set; }

        public bool Enter(object data)
        {
            return OnEnter(data);
        }

        public bool Exit()
        {
            return OnExit();
        }

        public bool TryTransTo(int id)
        {
            return OnTryTransTo(id);
        }

        public bool Update(float dt)
        {
            return OnUpdate(dt);
        }

        protected abstract int OnStateID();
        protected abstract bool OnEnter(object data);
        protected abstract bool OnExit();
        protected abstract bool OnTryTransTo(int id);
        protected abstract bool OnUpdate(float dt);
    }
}
