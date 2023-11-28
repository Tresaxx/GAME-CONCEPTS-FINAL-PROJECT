using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 1f;
    private float jumpingPower = 4f;
    private bool isFacingRight = true;
    private Animator animate;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start(){
        animate = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(animate != null){
            if(rb.velocity.x == 0 && rb.velocity.y == 0 && IsGrounded()){
                animate.SetTrigger("Idle");
            }
            if(rb.velocity.y < 0 && !(IsGrounded())){
                animate.SetTrigger("JumpDown");
            }
            if(IsGrounded()){
                    animate.SetTrigger("Land");
                }
            if(Input.GetButtonDown("Jump") && IsGrounded()){
                animate.SetTrigger("JumpUp");
            }
            if(rb.velocity.x != 0 && rb.velocity.y == 0 && IsGrounded()){
                animate.SetTrigger("Run");
            }
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown("r"))
        {
            rb.velocity = new Vector2(rb.velocity.x * 2, rb.velocity.y);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
