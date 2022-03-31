using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float spawnDistance;
    
    // Start is called before the first frame update
    void Start() {
        if(projectilePrefab == null)
            this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Vector2 mousePos  = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2) transform.position).normalized;

            GameObject projGO = Instantiate(projectilePrefab, transform.position + ((Vector3) direction) * spawnDistance, Quaternion.identity);
            Projectile projComp = projGO.GetComponent<Projectile>();

            projComp.direction = projComp.direction.magnitude * direction;
        }
    }
}
