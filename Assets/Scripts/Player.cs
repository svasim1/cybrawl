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
    [SerializeField] private float JumpForce;
    [SerializeField] private bool IsGroundedBool;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;
    public int JumpCount;
    public int MaxJumpCount = 2;
    public bool HasJumped = false;



    private Rigidbody2D rb;

    public Vector2 Movement;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

        IsGroundedBool = true;

        GroundCheck = transform.Find("GroundCheck");
    }

    private void Update()
    {
        Movement.x = Input.GetAxisRaw(inputNameHorizontal);
        Movement.y = Input.GetAxisRaw(inputNameVertical);
    }

    private void FixedUpdate()
    {
        Run();
        Jump();
    }

    void Run(){
        rb.velocity = new Vector2(Movement.x * speed, rb.velocity.y);
    }

    void Jump(){

        if(Movement.y > 0){
            if(IsGroundedBool == true){
                JumpCount++;
                HasJumped = true;
                rb.velocity = new Vector2(rb.velocity.x, Movement.y * JumpForce);
            }
            // else if(IsGroundedBool == false && HasJumped == true){
            //     JumpCount++;
            //     rb.velocity = new Vector2(rb.velocity.x, Movement.y * JumpForce);
            // }
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
    if(collision.gameObject.CompareTag("Ground")){
        IsGroundedBool = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            IsGroundedBool = false;
        }
    }
}