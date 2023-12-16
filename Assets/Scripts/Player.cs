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
    public bool powerUp = false;
    public bool activePowerUp = false;
    public float powerTime = 8f;
    public float originalpowerTime = 8f;
    public float multiplier = 2f;
    private float currentMul;
    private float timer = 0.0f;
    public float powerUpsGot = 0.0f;
    public bool puzzleActive = false;
    public float puzzleTimer = 0.0f;
    public float puzzleTime;
    public AudioSource powerUpSound;
    public AudioSource powerDownSound;
    private Animator animate;
    public GameManager GameManager;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;

    void Start(){
        animate = GetComponent<Animator>();
        Physics2D.autoSimulation = true;
    }

    void Update()
    {
        if(puzzleActive == false){
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
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower + speed/2);
            }

            else if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f + speed/2);
            }

            Flip();

            if(rb.position.y <= -4){
                GameManager.GameOver();
                Physics2D.autoSimulation = false;
            } else {
                Physics2D.autoSimulation = true;
            }
            //if(ScoreManager.instance.score < 100000){
                multiplier = 2 + (powerUpsGot * 0.001f * ScoreManager.instance.score/100000);
            //}   else {
                //multiplier = 3.0f;
            //}
            Debug.Log(speed);

            if(powerUp == true){
                timer += Time.deltaTime;
                ScoreManager.instance.PowerUpTime(powerTime - timer);
                if(timer > powerTime){
                    if(powerTime > 8.0f){
                        speed -= multiplier - 2;
                    }
                    timer -= powerTime;
                    powerTime = originalpowerTime;
                    speed = speed/currentMul;
                    activePowerUp = false;
                    powerUp = false;
                    powerDownSound.Play(0);
                }
            }
        } else {
            puzzleTimer += Time.deltaTime;
            if(puzzleTimer > puzzleTime){
                puzzleActive = false;
                puzzleTimer -= puzzleTime;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (roll)
        {
            rb.velocity = new Vector2(speed * (transform.localScale.x * 10), rb.velocity.y);
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

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "PowerUp" && activePowerUp == false){
            powerUp = true;
        } else if(collision.gameObject.tag == "PowerUp" && activePowerUp == true){
            ScoreManager.instance.AddPoint(5000);
            powerTime += originalpowerTime;
            Destroy(collision.gameObject);
            powerUpsGot++;
            speed += multiplier - 2;
            powerUpSound.Play(0);
        }
        if (collision.gameObject.tag == "PowerUp" && powerUp == true && activePowerUp == false){
            powerUpSound.Play(0);
            activePowerUp = true;
            ScoreManager.instance.AddPoint(5000);
            Destroy(collision.gameObject);
            currentMul = multiplier;
            speed = speed * currentMul;
            powerUpsGot++;
        }
        if(collision.gameObject.tag == "Puzzle"){
            Destroy(collision.gameObject);
            Physics2D.autoSimulation = false;
            puzzleActive = true;
        }
    }
}
