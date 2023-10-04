using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    internal float damage;

    void OnCollisionEnter2D(Collision2D collision) {

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

}
