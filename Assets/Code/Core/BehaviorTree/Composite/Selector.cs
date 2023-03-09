using UnityEngine;

namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 按顺序运行子元素，直到其中一个子元素成功(如果其中一个子元素成功，则成功)。
    /// </summary>
    public class Selector : Composite
    {
        private const string NAME = "Selector";
        private int _currentIndex = -1;

        public Selector(params Node[] children) : base(NAME, children) { }

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
            _currentIndex = -1;
            ProcessChildren();
        }

        protected override void DoStop()
        {
            Children[_currentIndex].Stop();
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
                    Children[_currentIndex].Start();
                }
            }
            else
            {
                Stopped(false);
            }
        }

        protected override void Stopped(bool success)
        {
            base.Stopped(success);
        }

        /// <summary>
        /// 子节点请求 关闭所有子节点时，应该做的操作
        /// </summary>
        /// <param name="abortChild"></param>
        /// <param name="immediateRestart">true:当前子节点停用返回false，启动请求中的子节点，否则停用返回true  false:当前子节点停用返回true，停用并返回true，否则停用返回false</param>
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

        /// <summary>
        /// 子节点停用时的操作
        /// </summary>
        /// <param name="child"></param>
        /// <param name="succeeded">true:停用当前节点并返回true false:按顺序启用下一个节点</param>
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
