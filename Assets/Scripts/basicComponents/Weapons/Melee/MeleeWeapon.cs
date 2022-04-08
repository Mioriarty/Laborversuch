using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Laborversuch/MeeleWeapon")]
public class MeleeWeapon : ScriptableObject
{
    public float range;
    public float angle;
    public int damage;
    public float knockback;
}
