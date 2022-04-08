using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponHandler : MonoBehaviour
{
    [SerializeField] private MeleeWeapon weapon;
    [SerializeField] private LayerMask enemyMask;

    public void Hit(Vector3 direction) {
        direction.y = 0;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, weapon.range, enemyMask);
        foreach(Collider collider in hitColliders) {
            Vector3 vecToEnemy = collider.transform.position - transform.position;
            vecToEnemy.y = 0;


            float enemyAngle = Vector3.Angle(direction, vecToEnemy);
            if(enemyAngle < weapon.angle) {
                Health health = collider.GetComponent<Health>();
                if(health != null)
                    health.ChangeHealth(-weapon.damage);
                
                KnockbackReciever knockbackReciever = collider.GetComponent<KnockbackReciever>();
                if(knockbackReciever != null)
                    knockbackReciever.Apply(vecToEnemy, weapon.knockback);
            }
        }
    }
}