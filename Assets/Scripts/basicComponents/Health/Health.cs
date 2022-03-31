using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int initialHealth;
    private int currentHealth;

    public UnityEvent<int> healthChanged;
    public UnityEvent died;

    void Start() {
        currentHealth = initialHealth;
    }

    public void ChangeHealth(int change) {
        currentHealth += change;
        healthChanged.Invoke(change);
        
        if(currentHealth <= 0)
            died.Invoke();
    }
}
