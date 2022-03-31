using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool destroyOnCollision = true;
    [SerializeField] private int numHitEnemiesToDestroy = 1;
    [SerializeField] private LayerMask canDealDamageLayers;

    private int countAllreadyHitEnemies = 0;

    [Header("Movement")]
    [SerializeField] private Vector2 direction;
    [SerializeField] private float range;
    [SerializeField] private bool infiniteRange;

    private Vector2 startPos;

    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    void Update() {
        rb.velocity = direction;

        if(!infiniteRange && Vector2.Distance(startPos, transform.position) > range) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        // Check if it is a hittable enemy
        if(canDealDamageLayers == (canDealDamageLayers | (1 << collision.gameObject.layer))) {
            Health health = collision.GetComponent<Health>();

            if(health != null) {
                health.ChangeHealth(-damage);

                countAllreadyHitEnemies++;
                if(countAllreadyHitEnemies >= numHitEnemiesToDestroy)
                    Destroy(gameObject);
            }
        } else {
            // It is a different object in the scene

            if(destroyOnCollision)
                Destroy(gameObject);
        }
    }
}
