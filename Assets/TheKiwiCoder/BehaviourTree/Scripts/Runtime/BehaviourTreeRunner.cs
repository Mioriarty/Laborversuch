using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees {
    public class BehaviourTreeRunner : MonoBehaviour {

        // The main behaviour tree asset
        public BehaviourTree tree;

        // Storage container object to hold game object subsystems
        public Context context;

        // Start is called before the first frame update
        void Start() {
            if(context == null)
                context = new Context();

            context.gameObject = gameObject;
            tree = tree.Clone();
            tree.Bind(context);
        }

        // Update is called once per frame
        void Update() {
            if (tree) {
                tree.Update();
            }
        }

        private void OnDrawGizmosSelected() {
            if (!tree) {
                return;
            }

            BehaviourTree.Traverse(tree.rootNode, (n) => {
                if (n.drawGizmos) {
                    n.OnDrawGizmos();
                }
            });
        }
    }
}