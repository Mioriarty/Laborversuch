using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BasicAiContext : BehaviourTrees.Context
{
    public Transform player;

    void OnEnable() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
