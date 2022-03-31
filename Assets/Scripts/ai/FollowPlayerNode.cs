using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class FollowPlayerNode : ActionNode
{
    public float speed = 2f;

    public float successDistance = 10f;

    private FollowTarget followTarget;

    protected override void OnStart() {
        followTarget = context.gameObject.GetComponent<FollowTarget>();
        followTarget.StartFollowing();
    }

    protected override void OnStop() {
        followTarget.StopFollowing();
        context.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    protected override State OnUpdate() {
        if(Vector2.Distance(context.gameObject.transform.position, followTarget.target.position) < successDistance) {
            return State.SUCCESS;
        } else {
            return State.RUNNING;
        }
    }
}
