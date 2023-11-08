using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetableObject : MonoBehaviour
{
    // Health of the object
    public int health = 100;

    // Finction to deal damage to the object
    public void TakeDamage(float damage)
    {
        // Reduce health by the damage dealt
        health -= (int)damage;

        // If health is 0 or less, call Die()
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Destroy object with TargetableObject.cs
        Destroy(gameObject);
    }
}
