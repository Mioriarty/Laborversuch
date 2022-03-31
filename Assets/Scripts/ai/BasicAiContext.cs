using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAiContext : BehaviourTrees.Context
{
    public Transform player;

    void Start() {
        if(player == null) {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
