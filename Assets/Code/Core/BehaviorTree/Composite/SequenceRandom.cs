namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 以随机顺序运行子节点，直到其中一个失败(如果没有子节点失败，则成功)。注意，对于打断规则，最初的顺序定义了优先级。
    /// </summary>
    public class SequenceRandom : Composite
    {
        private const string NAME = "SequenceRandom";
        private System.Random _random;
        private int _currentIndex = -1;
        private int[] _randomizedOrder;

        public SequenceRandom(params Node[] children) : base(NAME, children)
        {
            _random = new System.Random();
            _randomizedOrder = new int[children.Length];
            for (int i = 0; i < Children.Length; i++)
            {
                _randomizedOrder[i] = i;
            }
        }

        protected override void DoStart()
        {
            for (int i = 0; i < Children.Length; i++)
            {
                if (Children[i].CurState != State.INACTIVE)
                {
                    UnityEngine.Debug.LogError("出错了，有非激活状态的子节点!");
                    break;
                }
            }
            _currentIndex = -1;

            int len = _randomizedOrder.Length;
            while (len > 1)
            {
                int next = _random.Next(len--);
                int temp = _randomizedOrder[len];
                _randomizedOrder[len] = _randomizedOrder[next];
                _randomizedOrder[next] = temp;
            }

            ProcessChildren();
        }

        protected override void DoStop()
        {
            Children[_randomizedOrder[_currentIndex]].Stop();
        }

        private void ProcessChildren()
        {
            if (++_currentIndex < Children.Length)
            {
                if (IsStopRequested)
                {
                    Stopped(false);
                }
                else
                {
                    Children[_randomizedOrder[_currentIndex]].Start();
                }
            }
            else
            {
                Stopped(true);
            }
        }

        public override void StopLowerPriorityChildrenForChild(Node abortChild, bool immediateRestart)
        {
            int indexForChild = 0;
            bool found = false;
            foreach (Node currentChild in Children)
            {
                if (currentChild == abortChild)
                {
                    found = true;
                }
                else if (!found)
                {
                    indexForChild++;
                }
                else if (found && currentChild.IsActive)
                {
                    if (immediateRestart)
                    {
                        _currentIndex = indexForChild - 1;
                    }
                    else
                    {
                        _currentIndex = Children.Length;
                    }
                    currentChild.Stop();
                    break;
                }
            }
        }

        protected override void DoChildStopped(Node child, bool succeeded)
        {
            if (succeeded)
            {
                ProcessChildren();
            }
            else
            {
                Stopped(false);
            }
        }
    }
}
