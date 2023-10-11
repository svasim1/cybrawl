using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetableObject : MonoBehaviour
{
    public int health = 10;

    public void TakeDamage(float damage)
    {
        health -= (int)damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Code to handle player death
    }
}
