﻿using Code.Core.AI.BehaviorTree;
using Code.Core.AI.BehaviorTree.Task;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPBehaveExampleEnemyAI : MonoBehaviour
{
    private Blackboard blackboard;
    private Root behaviorTree;

    void Start()
    {
        // create our behaviour tree and get it's blackboard
        behaviorTree = CreateBehaviourTree();
        blackboard = behaviorTree.Blackboard;
        // start the behaviour tree
        behaviorTree.Start();
    }

    private Root CreateBehaviourTree()
    {
        // we always need a root node
        return new Root(

            // kick up our service to update the "playerDistance" and "playerLocalPos" Blackboard values every 125 milliseconds
            new Service(0.125f, UpdatePlayerDistance,

                new Selector(

                    // check the 'playerDistance' blackboard value.
                    // When the condition changes, we want to immediately jump in or out of this path, thus we use IMMEDIATE_RESTART
                    new BlackboardCondition("playerDistance", Operator.IS_SMALLER, 7.5f, Stops.IMMEDIATE_RESTART,

                        // the player is in our range of 7.5f
                        new Sequence(
                            // set color to 'red'
                            new ActionTask(() => SetColor(Color.red)) { Label = "Change to Red" },

                            // go towards player until playerDistance is greater than 7.5 ( in that case, _shouldCancel will get true )
                            new ActionTask((bool _shouldCancel) =>
                            {
                                if (!_shouldCancel)
                                {
                                    MoveTowards(blackboard.Get<Vector3>("playerLocalPos"));
                                    return ActionTask.Result.PROGRESS;
                                }
                                else
                                {
                                    return ActionTask.Result.FAILED;
                                }
                            })
                            { Label = "Follow" }
                        )
                    ),

                    // park until playerDistance does change
                    new Sequence(
                        new ActionTask(() => SetColor(Color.grey)) { Label = "Change to Gray" },
                        new WaitUntilStopped()
                    )
                )
            )
        );
    }

    private void UpdatePlayerDistance()
    {
        Vector3 playerLocalPos = this.transform.InverseTransformPoint(GameObject.FindGameObjectWithTag("Player").transform.position);
        behaviorTree.Blackboard["playerLocalPos"] = playerLocalPos;
        behaviorTree.Blackboard["playerDistance"] = playerLocalPos.magnitude;
    }

    private void MoveTowards(Vector3 localPosition)
    {
        transform.localPosition += localPosition * 0.5f * Time.deltaTime;
    }

    private void SetColor(Color color)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", color);
    }
}
