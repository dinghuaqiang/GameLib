using UnityEngine;

namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 按随机顺序运行子进程，直到其中一个子进程成功(如果其中一个子进程成功，则成功)。注意，对于打断规则，最初的顺序定义了优先级。
    /// </summary>
    public class SelectorRandom : Composite
    {
        private const string NAME = "SelectorRandom";
        private System.Random _random;
        private int _curIndex = -1;
        private int[] _randomizedOrder;

        public SelectorRandom(params Node[] children) : base(NAME, children)
        {
            _random = new System.Random();
            _randomizedOrder = new int[children.Length];
        }

        protected override void DoStart()
        {
            for (int i = 0; i < Children.Length; i++)
            {
                if (Children[i].CurState != State.INACTIVE)
                {
                    Debug.LogError("出错了，有非激活状态的子节点!");
                    break;
                }
            }
            _curIndex = -1;

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
            Children[_randomizedOrder[_curIndex]].Stop();
        }

        private void ProcessChildren()
        {
            if (++_curIndex < Children.Length)
            {
                if (IsStopRequested)
                {
                    Stopped(false);
                }
                else
                {
                    Children[_randomizedOrder[_curIndex]].Start();
                }
            }
            else
            {
                Stopped(false);
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
                        _curIndex = indexForChild - 1;
                    }
                    else
                    {
                        _curIndex = Children.Length;
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
                Stopped(true);
            }
            else
            {
                ProcessChildren();
            }
        }
    }
}
