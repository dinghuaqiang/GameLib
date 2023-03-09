using System.Collections.Generic;

namespace GameLib.Core.FSM
{
    //状态机
    public class FiniteStateMachine
    {
        //当前状态机所有的状态
        private Dictionary<int, IState> _allState = new Dictionary<int, IState>();
        //状态机所在宿主
        private object _host;
        //当前状态
        private IState _currentState;


        public IState CurrentState
        {
            get
            {
                return _currentState;
            }
        }

        //状态机所在宿主
        public object Host { get { return _host; } set { _host = value; } }

        public FiniteStateMachine(object host)
        {
            Host = host;
        }

        public void Register(IState state)
        {
            if (state != null)
            {
                _allState[state.ID] = state;                
                state.FSM = this;
            }
        }   

        public bool TransToState(int destID, object p)
        {
            bool canTrans = true;
            if (_currentState != null)
            {
                canTrans = _currentState.TryTransTo(destID);
                if (canTrans)
                {
                    _currentState.Exit();
                    _currentState = null;
                }
            }

            if (canTrans)
            {
                IState state;
                if (_allState.TryGetValue(destID, out state))
                {
                    _currentState = state;
                    _currentState.Enter(p);
                    return true;
                }
            }
            return false;
        }

        public void Update(float dt)
        {
            if (_currentState != null)
            {
                _currentState.Update(dt);
            }
        }

    }
}
