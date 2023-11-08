using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float damage;
    public float rotationSpeed = 1f;
    public string saw;

    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<TargetableObject>().TakeDamage(damage);
        }
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
}
