using GameLib.Core.Base;
using GameLib.Core.FSM;

namespace Code.Logic.System
{
    public class GameStateSystem : ISystem, IStateSystem
    {
        public FiniteStateMachine Fsm => throw new global::System.NotImplementedException();

        public void ChangeState(int stateId, object arg = null)
        {
        }

        public IGameState GetCurState()
        {
            throw new global::System.NotImplementedException();
        }

        public IGameState GetNextState()
        {
            throw new global::System.NotImplementedException();
        }

        public IGameState GetPrevState()
        {
            throw new global::System.NotImplementedException();
        }

        public IGameState GetStateById(int id)
        {
            throw new global::System.NotImplementedException();
        }

        public void HandlerMessage(object msg)
        {
            throw new global::System.NotImplementedException();
        }

        public void Initialize()
        {
            
        }

        public bool IsCurState(int stateID)
        {
            throw new global::System.NotImplementedException();
        }

        public void UnInitialize()
        {
            
        }

        public void Update(float dt)
        {
            
        }
    }
}
