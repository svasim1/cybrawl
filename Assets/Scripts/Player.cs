using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Player")]
    public Transform GroundCheck;
    public Transform WallCheck;
    public LayerMask GroundLayer;

    [Header("Player Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private bool IsGroundedBool;
    [SerializeField] private bool IsTouchingWall;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;
    public int JumpCount;
    public int MaxJumpCount = 2;
    public bool HasJumped = false;
    public bool SecondJump;
    public float LastOnGround;



    private Rigidbody2D rb;

    public Vector2 Movement;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

        IsGroundedBool = true;

        GroundCheck = transform.Find("GroundCheck");
        WallCheck = transform.Find("WallCheck");
    }

    private void Update()
    {
        Movement.x = Input.GetAxisRaw(inputNameHorizontal);
        Movement.y = Input.GetAxisRaw(inputNameVertical);

        LastOnGround -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Run();
        Jump();
        if(IsGroundedBool == true){
            LastOnGround = 0.1f;
        }
    }

    void Run(){
        rb.velocity = new Vector2(Movement.x * speed, rb.velocity.y);
    }

    void Jump(){

        if(Movement.y > 0){
            if(IsGroundedBool == true){
                Debug.Log("Jump1");
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                return;
            }
            else if(SecondJump == true && LastOnGround <= -0.3f){
                Debug.Log("Jump2");
                rb.velocity = new Vector2(rb.velocity.x, Movement.y * JumpForce);
                SecondJump = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
    if(collision.gameObject.CompareTag("Ground")){
        //if(collision.collider == transform.Find("GroundCheck").GetComponent<Collider2D>()){
            Debug.Log("Grounded");
            IsGroundedBool = true;
            SecondJump = true;
            //}
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            IsGroundedBool = false;
        }
    }
}