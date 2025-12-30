using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool facingLeft = true;

    public Joystick joystick;

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGrounded;

    private Animator anim;

    public VectorValue pos;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        transform.position = pos.Value;
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(joystick.Horizontal) > 0.1f)
        {
            moveInput = joystick.Horizontal;
        }
        rb.velocity = new Vector2(moveInput *  speed, rb.velocity.y);
        if(facingLeft == false && moveInput < 0)
        {
            Flip();
        }
        else if (facingLeft == true && moveInput > 0)
        {  Flip(); }
        
        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }

    private void Update()
    {
        float verticalMove = joystick.Vertical;
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGrounded);
        if (isGrounded == true && (verticalMove >= .5f || Input.GetKeyDown(KeyCode.Space)))
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOf");
        }

        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }

    public void OnJumpButtonDown()
    {
        if (isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOf");
        }
    }
    void Flip()
    {
        facingLeft = !facingLeft;
        // Vector3 scaler = transform.localScale;
        // scaler.x *= -1;
        // transform.localScale = scaler;

        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
