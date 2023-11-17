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
    [SerializeField] public string fireButton;
    public bool SecondJump;
    public bool DBTrue;
    public float LastOnGround;

    public bool facingRight = true;

    [Header("Player Conditions")]
    public bool IsGrounded;
    public bool IsMoving;
    public bool OnWall;
    public bool IsFalling;
    public bool IsJumping;

    private Rigidbody2D rb;
    private Animator anim;

    public Vector2 Movement;
    private void Start()
    {
        // Define the rigidbody and animator
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Define the GroundCheck and WallCheck
        GroundCheck = transform.Find("GroundCheck");
        WallCheck = transform.Find("WallCheck");

        IsGroundedBool = true;
    }

    private void Update()
    {
        // Get the input from the player
        Movement.x = Input.GetAxisRaw(inputNameHorizontal);
        Movement.y = Input.GetAxisRaw(inputNameVertical);

        // Check if the player is touching the ground
        LastOnGround -= Time.deltaTime;
        Update_Conditions();
    }

    private void FixedUpdate()
    {
        // Check for player input
        Run();
        Jump();
        CheckWeapon();

        // Check if the player is touching the ground to chage LastOnGround
        if (IsGroundedBool == true)
        {
            LastOnGround = 0.1f;
        }
    }

    void Update_Conditions()
    {
        IsGrounded = IsGroundedBool;
        IsMoving = Movement.x != 0;
        OnWall = false;
        IsFalling = rb.velocity.y < 0 && !IsGrounded;
        IsJumping = rb.velocity.y > 0;
        
        anim.SetBool("IsGrounded", IsGrounded);
        anim.SetBool("IsMoving", IsMoving);
        anim.SetBool("OnWall", OnWall);
        anim.SetBool("IsFalling", IsFalling);
        anim.SetBool("IsJumping", IsJumping);
    }

    void Run()
    {
        // Move the player based on the input
        rb.velocity = new Vector2(Movement.x * speed, rb.velocity.y);
    }

    void Jump()
    {
        // Move the player based on the input
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

                // Play the airboost sound
                GameObject.Find("AudioHandler").transform.Find("SFX").Find("Airboost").GetComponent<AudioSource>().Play();
            }
        }
    }

    void CheckWeapon(){
        GameObject Weapon;
        Weapon = transform.Find("WeaponHolder").gameObject;
        if (Weapon.transform.childCount > 0 && Movement.y < 0) {
            rb.velocity = new Vector2(rb.velocity.x, Movement.y * JumpForce * -1);
            Destroy(Weapon.transform.GetChild(0).gameObject);
            WeaponCollect weaponCollect = GetComponent<WeaponCollect>();
            Debug.Log(weaponCollect);

            // Play the consume sound
            GameObject.Find("AudioHandler").transform.Find("SFX").Find("Consume").GetComponent<AudioSource>().Play();

            if (weaponCollect != null) {
                weaponCollect.hasWeapon = false;
            }
        } else {
            Debug.Log("Weapon has no children");
        }
    }

    void LateUpdate()
    {
        // Flip the player sprite
        if (Movement.x < 0 && facingRight)
        {
            Flip();
        }
        else if (Movement.x > 0 && !facingRight)
        {
            Flip();
        }
    }

    // Flip the player sprite
    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    // Function when entering collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player is touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Grounded");
            IsGroundedBool = true;
            SecondJump = true;
        }
    }
    
    // Function when exiting collider
    void OnTriggerExit2D(Collider2D collision)
    {   
        // Check if the player is touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGroundedBool = false;
        }
    }
}