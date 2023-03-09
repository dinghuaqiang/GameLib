using UnityEngine;

namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 按顺序运行子节点，直到其中一个失败(如果所有子节点都没有失败，则成功。
    /// </summary>
    public class Sequence : Composite
    {
        private const string NAME = "Sequence";
        private int _curIndex = -1;
        public Sequence(params Node[] children) : base(NAME, children){}

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
                    Children[_curIndex].Start();
                }
            }
            else
            {
                Stopped(true);
            }
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
            ProcessChildren();
        }

        protected override void DoStop()
        {
            if (Children.Length > _curIndex && Children[_curIndex] != null)
            {
                Children[_curIndex].Stop();
            }
        }

        public override void StopLowerPriorityChildrenForChild(Node abortChild, bool immediateRestart)
        {
            int childIndex = 0;
            bool isFound = false;
            for (int i = 0; i < Children.Length; i++)
            {
                Node curChild = Children[i];
                if (curChild == abortChild)
                {
                    isFound = true;
                }
                else if (!isFound)
                {
                    childIndex++;
                }
                else if (isFound && curChild.IsActive)
                {
                    if (immediateRestart)
                    {
                        _curIndex = childIndex - 1;
                    }
                    else
                    {
                        _curIndex = Children.Length;
                    }
                    curChild.Stop();
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
