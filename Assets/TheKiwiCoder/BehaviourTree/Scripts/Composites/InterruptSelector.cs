using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees {
    public class InterruptSelector : Selector {
        protected override State OnUpdate() {
            int previous = current;
            base.OnStart();
            var status = base.OnUpdate();
            if (previous != current) {
                if (children[previous].state == State.RUNNING) {
                    children[previous].Abort();
                }
            }

            return status;
        }
    }
}