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

        // Get the AudioSource component and play the shoot sound
        GameObject.Find("AudioHandler").transform.Find("SFX").Find("Hurt").GetComponent<AudioSource>().Play();
        Debug.Log("Played hurt sound");
    }

    private void Die()
    {
        // Destroy object with TargetableObject.cs
        Destroy(gameObject);

        // Get the AudioSource component and play the shoot sound
        GameObject.Find("AudioHandler").transform.Find("SFX").Find("Death").GetComponent<AudioSource>().Play();
        Debug.Log("Played death sound");
    }
}
