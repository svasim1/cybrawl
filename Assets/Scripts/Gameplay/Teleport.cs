using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    private BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // This method is called when another object enters the collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the collider is the player
        if (other.gameObject == player)
        {
            // Teleport the player to the coordinates (0, 0)
            player.transform.position = new Vector3(3, 1, player.transform.position.z);
        }
    }
}