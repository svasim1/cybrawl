using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    internal float damage;

    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<TargetableObject>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
