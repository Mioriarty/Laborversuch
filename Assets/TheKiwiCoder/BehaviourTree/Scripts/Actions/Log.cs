using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees {
    public class Log : ActionNode
    {
        public string message;

        protected override void OnStart() {
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            Debug.Log($"Behaviour Tree Node: {message}");
            return State.SUCCESS;
        }
    }
}
