using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackReciever : MonoBehaviour
{
    [SerializeField] private float resistance;

    private Vector3 kbDirection;
    private float kbStrength;
    private float lastApplyTime = 0;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void Apply(Vector3 direction, float strength) {
        this.kbDirection = direction.normalized;
        this.kbStrength = strength;
        this.lastApplyTime = Time.time;
    }

    void LateUpdate() {
        float remainingStrength = kbStrength - resistance * (Time.time - this.lastApplyTime);
        if(remainingStrength <= 0)
            return;

        rb.velocity += this.kbDirection * remainingStrength;
    }
}
