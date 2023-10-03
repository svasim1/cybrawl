using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private Vector2 Movement;
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

        CheckInput();
        
        if(IsGroundedBool && rb.velocity.y > 0f){
            Movement.y = 0f;
        }
        if(!IsGroundedBool && rb.velocity.y < 0f){
            Movement.y = -1f;
        }
        rb.velocity = new Vector2(Movement.x * MoveSpeed, Movement.y * JumpForce);

        if(!FlipRight && Movement.x > 0f){
            Player1Flip();
            }
        else if(FlipRight && Movement.x < 0f){
            Player1Flip();
            }

    }


    void CheckInput(){

        if(Input.GetKeyDown(KeyCode.W) && IsGroundedBool){
            Movement.y = 1f;
        }
        if(Input.GetKeyDown(KeyCode.A)){
            Movement.x = -1f;
        }
        if(Input.GetKeyDown(KeyCode.D)){
            Movement.x = 1f;
        }
        if(Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f){
            Movement.y = 0f;
        }
        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)){
            Movement.x = 0f;
        }
        if(Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D)){
            Movement.x = 0f;
        }
    }
    void FixedUpdate(){
        
        // if(Input.GetKeyDown("w") && IsGroundedBool){
        //     Vertical = 1f;
        // }
        // if(Input.GetKeyDown("a")){
        //     Horizontal = -1f;
        // }
        // if(Input.GetKeyDown("d")){
        //     Horizontal = 1f;
        // }
        // if(Input.GetKeyUp("a")){
        //     Horizontal = 0f;
        // }
        // if(Input.GetKeyUp("d")){
        //     Horizontal = 0f;
        // }
        // if(Input.GetKeyUp("w") && rb.velocity.y > 0f){
        //     Vertical = 0f;
        // }
    }

    // public void Player1Movement(InputAction.CallbackContext context){

    //     Horizontal = context.ReadValue<Vector2>().x;
    //     Vertical = context.ReadValue<Vector2>().y;

    // }

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
    // yes
}
