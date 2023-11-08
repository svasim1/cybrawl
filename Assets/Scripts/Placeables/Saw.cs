using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float damage;
    public float rotationSpeed = 1f;

    void OnCollisionEnter2D(Collision2D collision) {

        // Check for collision with object tagged Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player
            collision.gameObject.GetComponent<TargetableObject>().TakeDamage(damage);
        }
    }

    void FixedUpdate()
    {
        // Rotate the saw
        transform.Rotate(0, 0, rotationSpeed);
    }
}
