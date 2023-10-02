using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{

    [SerializeField] public PlayerInputActions _playerInput;
    [SerializeField] public float jumpForce = 8f;
    [SerializeField] public Rigidbody2D _rb;
    
    void onValidate(){

            _rb = gameObject.GetComponent<Rigidbody2D>();
            _playerInput = gameObject.GetComponent<PlayerInput>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = _playerInput.actions["Move"].ReadValue<Vector2>().x;
        bool Jump = _playerInput.actions["Move"].ReadValue<Vector2>().y > 0;

        if(Jump){
            _rb.velocity = new Vector2(Horizontal, jumpForce);        
            }
        else{
            _rb.velocity = new Vector2(Horizontal, _rb.velocity.y);
        }
    }
}
