using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PLayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float jumpforce = 5f;
    Vector2 moveInput;
    public bool IsMoving{get; private set;}
    public bool isFacingRight = true;

    TouchingDirections touchingDirection;

    Rigidbody2D rb;
    public float fallGravityScale = 5;
    [SerializeField]
    private bool _isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirection = GetComponent<TouchingDirections>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {

        rb.velocity = new Vector2(moveInput.x*walkSpeed, rb.velocity.y);
        

        if(rb.velocity.y > 0){
            rb.gravityScale = rb.gravityScale;
        }
        else
        {
            rb.gravityScale = fallGravityScale;
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);
    }
 

    public bool IsFacingRight { get { return isFacingRight;}
    private set{
        if(isFacingRight != value){
            transform.localScale *= new Vector2(-1,1);
        }
        isFacingRight = value;
    }
    }

    public void SetFacingDirection(Vector2 moveInput){
        
        if(moveInput.x > 0 && !isFacingRight){
            IsFacingRight = true;
        }
        else if(moveInput.x < 0 && isFacingRight){
            IsFacingRight = false;
        }
    }


    public float CurrentMoveSpeed{
        get{
            if(IsMoving && !touchingDirection.IsOnWall){
                return walkSpeed;
            }
            else{
                return 0;
            }
        }
    }


    public void onJump(InputAction.CallbackContext context){
        if(context.started && touchingDirection.IsGrounded)
        {
            rb.AddForce(Vector2.up *jumpforce, ForceMode2D.Impulse);
            
        }
    }

    public bool IsGrounded{get{
        return _isGrounded;
    }private set{
        _isGrounded = value;
    }}
}

