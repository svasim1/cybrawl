using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Player")]
    public Transform GroundCheck;
    public Transform WallCheck;

    [Header("Player Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private bool IsGroundedBool;
    [SerializeField] private bool IsTouchingWall;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;

    [SerializeField] public string fireButton;
    public bool SecondJump;
    public bool DBTrue;
    public float LastOnGround;

    public bool facingRight = true;



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
        if (IsGroundedBool == true)
        {
            LastOnGround = 0.1f;
        }
    }

    // private bool DJHandler()
    // {
    //     if (Movement.y == 0)
    //     {
    //         SecondJump = true;
    //         return false;
    //     }
    //     else if (Movement.y > 0)
    //     {
    //         if (IsGroundedBool == true)
    //         {
    //             SecondJump = true;
    //             return false;
    //         }
    //         else
    //         {
    //             SecondJump = false;
    //             if (LastOnGround <= -0.2f)
    //             {
    //                 return true;
    //             }
    //             else
    //             {
    //                 return false;
    //             }
    //         }
    //     }
    // }

    void Run()
    {
        rb.velocity = new Vector2(Movement.x * speed, rb.velocity.y);
    }

    void Jump()
    {

        if (Movement.y > 0)
        {
            if (IsGroundedBool == true)
            {
                Debug.Log("Jump1");
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                return;
            }
            else if (SecondJump == true && LastOnGround <= -0.2f)
            {
                Debug.Log("Jump2");
                rb.velocity = new Vector2(rb.velocity.x, Movement.y * JumpForce);
                SecondJump = false;
            }
        }
    }

    void LateUpdate()
    {
        if (Movement.x < 0 && facingRight)
        {
            Flip();
        }
        else if (Movement.x > 0 && !facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //if(collision.collider == transform.Find("GroundCheck").GetComponent<Collider2D>()){
            Debug.Log("Grounded");
            IsGroundedBool = true;
            SecondJump = true;
            //}
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGroundedBool = false;
        }
    }
}