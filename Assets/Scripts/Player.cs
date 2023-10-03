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



    public float moveSpeed;
    public float MaxSpeed;
    public float jumpForce;
    public float moveHorizontal;
    public float moveVertical;
    public bool IsGroundedBool;
    public bool isJumpFalling;
    public float runAcceleration;
    public float runDecceleration;
    public float runAccAmount;
    public float runDeccAmount;
    public float runMaxSpeed;
    public float accInAir;
    public float decInAir;
    public bool OnWall;
    public float wallJumpX;
    public float WallJumpY;

    private Rigidbody2D rb;

    public Vector2 Movement;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

        IsGroundedBool = true;

        moveSpeed = 5f;
        wallJumpX = 10f;
        WallJumpY = 10f;
        MaxSpeed = 10f;
        jumpForce = 10f;
        accInAir = 0.5f;
        decInAir = 0.5f;
        runAcceleration = 10f;
        runDecceleration = 10f;
		runAccAmount = (50 * runAcceleration) / MaxSpeed;
		runDeccAmount = (50 * runDecceleration) / MaxSpeed;
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
    }

    void Run(){
        
        float targetSpeed = moveHorizontal * MaxSpeed;

        targetSpeed = Mathf.Lerp(rb.velocity.x, targetSpeed, 0.1f);

        float AccRate;

        if(!IsGroundedBool){
            AccRate = (Mathf.Abs(targetSpeed) > 0.01f) ? runAccAmount : runDeccAmount;
        }
        else{
            AccRate = (Mathf.Abs(targetSpeed) > 0.01f) ? runAccAmount * accInAir : runDeccAmount * decInAir;
        }

        if(Mathf.Abs(rb.velocity.x) > Mathf.Abs(targetSpeed)){
            AccRate = 0;
        }

        float SpeedDif = targetSpeed - rb.velocity.x;;

        float movement = AccRate * SpeedDif;

        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);
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