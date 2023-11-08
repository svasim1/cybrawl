using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitationPad : MonoBehaviour
{

    public float LevitationForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check collision with object tagged Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add upwards force to the player
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * LevitationForce * 2, ForceMode2D.Impulse);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check for collision with object tagged Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add downwards force to the player
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * LevitationForce * -2, ForceMode2D.Impulse);
        }
    }    

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Check for collision with object tagged Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add upwards force to the player while staying in the zone
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * LevitationForce , ForceMode2D.Impulse);
        }
    }

    
}
