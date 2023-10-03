using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Player")]
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    [Header("Player Movement")]
    [SerializeField] private float speed;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;


    private Rigidbody2D rb;

    public Vector2 Movement;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement.x = Input.GetAxisRaw(inputNameHorizontal);
        Movement.y = Input.GetAxisRaw(inputNameVertical);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Movement.x * speed * Time.fixedDeltaTime, Movement.y * speed * Time.fixedDeltaTime);
    }
}