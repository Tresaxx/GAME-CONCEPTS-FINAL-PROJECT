using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontal;
    public float speed = 1f;
    public float jumpingPower = 4f;
    public bool isFacingRight = true;
    public bool roll = false;
    private Animator animate;
    public GameManager GameManager;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;

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
            else if(horizontal != 0 && rb.velocity.y == 0 && IsGrounded()){
                animate.SetTrigger("Run");
            }
            if(IsGrounded()){
                animate.SetTrigger("Land");
                }
            else if(Input.GetButtonDown("Jump") && IsGrounded()){
                animate.SetTrigger("JumpUp");
            }
            else if(rb.velocity.y < 0 && !(IsGrounded())){
                animate.SetTrigger("JumpDown");
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

        if(rb.position.y <= -2){
            GameManager.GameOver();
            Physics2D.autoSimulation = false;
        } else {
            Physics2D.autoSimulation = true;
        }
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
        if (isFacingRight && horizontal < 0f && Time.timeScale != 0 || !isFacingRight && horizontal > 0f && Time.timeScale != 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
