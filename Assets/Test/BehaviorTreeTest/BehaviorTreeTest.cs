using Code.Core.AI.BehaviorTree;
using Code.Core.AI.BehaviorTree.Task;
using UnityEngine;

public class BehaviorTreeTest : MonoBehaviour
{
    private Node _behaviorTree = null;
    private int _count = 10;
    void Start()
    {
        _behaviorTree = CreateBehaviorTree();
        _behaviorTree.Start();
    }

    private Root CreateBehaviorTree()
    {
        return new Root(
            new Service(
                0.2f, OnService,
                new Sequence(
                    new ActionTask(OnActionTask),
                    new WaitUntilStopped()
                )
            )
        );
        //return new Root(
        //    new Service(0.5f, () => { _behaviorTree.Blackboard["foo"] = !_behaviorTree.Blackboard.Get<bool>("foo"); },
        //        new Selector(

        //            new BlackboardCondition("foo", Operator.IS_EQUAL, true, Stops.IMMEDIATE_RESTART,
        //                new Sequence(
        //                    new ActionTask(() => Debug.Log("foo")),
        //                    new WaitUntilStopped()
        //                )
        //            ),

        //            new Sequence(
        //                new ActionTask(() => Debug.Log("bar")),
        //                new WaitUntilStopped()
        //            )
        //        )
        //    )
        //);
    }

    private void OnService()
    {
        _count--;
        if (_count <= 0)
        {
            if (_behaviorTree != null && _behaviorTree.CurState == Node.State.ACTIVE)
            {
                _behaviorTree.Stop();
                Debug.LogError("终止行为树了！" + _count);
            }
        }
        Debug.Log("OnService _count = " + _count);
    }

    private void OnActionTask()
    {
        Debug.Log("OnActionTask");
    }
}
