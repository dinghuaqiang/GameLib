using System.Collections.Generic;
using UnityEngine;

namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 并行节点
    /// </summary>
    public class Parallel : Composite
    {
        public enum Policy
        {
            ONE,
            ALL,
        }
        private const string NAME = "Parallel";
        private Policy _failPolicy;
        private Policy _succPolicy;
        private int _childCount = 0;
        private int _runningCount = 0;
        private int _succeedCount = 0;
        private int _failedCount = 0;
        private bool _succStatus;
        private bool _childrenAborted;
        private Dictionary<Node, bool> _childResultDict;

        /// <summary>
        /// 当successPolicy为Policy.ONE。当其中一个孩子失败时，并行将停止，返回成功。
        /// 当failurePolicy为Policy.ONE。当其中一个孩子失败时，并行就会停止，返回失败。
        /// 如果并行没有因为Policy.ONE而停止。它会一直执行，直到所有的子节点都完成，然后如果所有的子节点都成功或者失败，它就会返回成功。
        /// </summary>
        public Parallel(Policy successPolicy, Policy failurePolicy, params Node[] children) : base(NAME, children)
        {
            _succPolicy = successPolicy;
            _failPolicy = failurePolicy;
            if (children != null)
            {
                _childCount = children.Length;
            }
            _childResultDict = new Dictionary<Node, bool>();
        }

        protected override void DoStart()
        {
            _childrenAborted = false;
            _runningCount = 0;
            _succeedCount = 0;
            _failedCount = 0;
            for (int i = 0; i < Children.Length; i++)
            {
                if (Children[i].CurState == State.INACTIVE)
                {
                    _runningCount++;
                    Children[i].Start();
                }
            }
        }

        protected override void DoStop()
        {
            if ((_runningCount + _succeedCount + _failedCount) != _childCount)
            {
                Debug.LogError("Parallel节点停止失败，个数不一!");
                return;
            }
            for (int i = 0; i < Children.Length; i++)
            {
                if (Children[i].IsActive)
                {
                    Children[i].Stop();
                }
            }
        }

        public override void StopLowerPriorityChildrenForChild(Node abortForChild, bool immediateRestart)
        {
            //重新启用当前子节点
            if (immediateRestart)
            {
                if (abortForChild.IsActive == false)
                {
                    if (_childResultDict.ContainsKey(abortForChild))
                    {
                        _succeedCount--;
                    }
                    else
                    {
                        _failedCount--;
                    }
                    _runningCount++;
                    abortForChild.Start();
                }
            }
            else
            {
                Debug.LogError("在并行节点上，所有的子节点都有相同的优先级，因此，如果给'immediateRestart'传递false，该方法什么也不做");
            }
        }

        protected override void DoChildStopped(Node child, bool succeeded)
        {
            _runningCount--;
            if (succeeded)
            {
                _succeedCount++;
            }
            else
            {
                _failedCount++;
            }
            if (_childResultDict.ContainsKey(child))
            {
                _childResultDict[child] = succeeded;
            }
            bool isAllChildsStarted = _runningCount + _succeedCount + _failedCount == _childCount;
            if (isAllChildsStarted)
            {
                if (_runningCount == 0)
                {
                    //子节点被之前的规则被中止掉了，这里不想去继承successState
                    if (!_childrenAborted)
                    {
                        if (_failPolicy == Policy.ONE && _failedCount > 0)
                        {
                            _succStatus = false;
                        }
                        else if (_succPolicy == Policy.ONE && _succeedCount > 0)
                        {
                            _succStatus = true;
                        }
                        else if (_succPolicy == Policy.ALL && _succeedCount == _childCount)
                        {
                            _succStatus = true;
                        }
                        else
                        {
                            _succStatus = false;
                        }
                    }
                    Stopped(_succStatus);
                }
                else if (!_childrenAborted)
                {
                    if (_succeedCount == _childCount || _failedCount == _childCount)
                    {
                        Debug.LogError("所有节点都执行成功或者失败了，这里有异常了。");
                        return;
                    }
                    if (_failPolicy == Policy.ONE && _failedCount > 0)
                    {
                        _succStatus = false;
                        _childrenAborted = true;
                    }
                    else if (_succPolicy == Policy.ONE && _succeedCount > 0)
                    {
                        _succStatus = true;
                        _childrenAborted = true;
                    }
                    if (_childrenAborted)
                    {
                        for (int i = 0; i < Children.Length; i++)
                        {
                            if (Children[i].IsActive)
                            {
                                Children[i].Stop();
                            }
                        }
                    }
                }
            }
        }
    }
}
