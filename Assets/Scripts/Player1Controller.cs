using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Player1")]
    public Rigidbody2D rb;
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    [Header("Player1 Movement")]
    [SerializeField]
    private float Horizontal;
    [SerializeField]
    private float Vertical;
    [SerializeField]
    private float MoveSpeed = 8f;
    [SerializeField]
    private float JumpForce = 7f;
    [SerializeField]
    private bool FlipRight = true;
    [SerializeField]
    private bool IsGroundedBool = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GroundCheck = transform.Find("GroundCheck");
    }

    void Update()
    {        



        if(Vertical >= 0f && IsGroundedBool){
            rb.velocity = new Vector2(Horizontal* MoveSpeed, Vertical * JumpForce);
        }
        else{
            rb.velocity = new Vector2(Horizontal* MoveSpeed, rb.velocity.y);
        }


        if(!FlipRight && Horizontal > 0f){
            Player1Flip();
            }
        else if(FlipRight && Horizontal < 0f){
            Player1Flip();
            }
    }

    public void Player1Movement(InputAction.CallbackContext context){

        Horizontal = context.ReadValue<Vector2>().x;
        Vertical = context.ReadValue<Vector2>().y;

    }

    public void Player1Flip(){

        FlipRight = !FlipRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
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

    // public void Player1Jump(InputAction.CallbackContext context){

    //     if(context.performed && IsGrounded()){
    //         Debug.Log("Jump");
    //         rb.velocity = new Vector2(rb.velocity.x, JumpForce);
    //     }
    //     if(context.canceled && rb.velocity.y > 0f){
    //         Debug.Log("Cancel");
    //         rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
    //     }
    // }
}
