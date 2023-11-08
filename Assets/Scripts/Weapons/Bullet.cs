using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // The damage the bullet deals, set by the bulletDamage in specific weapon script
    internal float damage;
    public string bullet;

    void Start()
    {
        // Ignore collisions between the bullet and the objects with the layer PassThrough
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("PassThrough"));
    }

    void OnCollisionEnter2D(Collision2D collision) {

        // Check if the bullet collided with an object with the tag Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player
            collision.gameObject.GetComponent<TargetableObject>().TakeDamage(damage);
        }

        // Else destroy the bullet
        Destroy(gameObject);
    }
}
