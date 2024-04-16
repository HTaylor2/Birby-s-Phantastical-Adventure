using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PLayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float jumpforce = 5f;
    Vector2 moveInput;
    public bool IsMoving{get; private set;}
    public bool isGrounded;
    public bool isFacingRight = true;

    Rigidbody2D rb;
    public float fallGravityScale = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        
        if(moveInput.y > 0 && isGrounded)
        {
            rb.AddForce(Vector2.up *jumpforce, ForceMode2D.Impulse);
            isGrounded = false;
        }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag ("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
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

}

