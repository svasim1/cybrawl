using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitationPad : MonoBehaviour
{

    public float LevitationForce;
    public string LevitationPadTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * LevitationForce * 2, ForceMode2D.Impulse);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * LevitationForce * -2, ForceMode2D.Impulse);
        }
    }    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * LevitationForce , ForceMode2D.Impulse);
        }
    }

    
}
