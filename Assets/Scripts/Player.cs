using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float speed = 1f;
    private float jumpingPower = 4f;
    private bool isFacingRight = true;
    private Animator animate;
    private bool roll = false;
    public GameManager GameManager;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start(){
        animate = GetComponent<Animator>();
    }

    void Update()
    {

        roll = Input.GetKeyDown(KeyCode.R);
        horizontal = Input.GetAxisRaw("Horizontal");
        if(animate != null){
            if(roll){
                animate.SetTrigger("Roll");
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

        else if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (roll)
        {
            rb.velocity = new Vector2(speed * transform.localScale.x * 10, rb.velocity.y);
        }

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
