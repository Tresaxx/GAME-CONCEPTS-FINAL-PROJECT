using UnityEngine;

public class FakeElonMusk : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float chaseSpeed = 5f; // Speed at which Fake Elon Musk chases the player
    public float catchDistance = 1.5f; // Distance at which Fake Elon Musk catches the player
    public Player playerScript;
    public GameManager GameManager;
    public float timer = 0.0f;
    public float waitTime = 5.0f; 

    private void Start()
    {
        // If the player reference is not assigned in the Inspector, find it using the tag "Player"
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogError("Player not found! Assign the player object or ensure it has the 'Player' tag.");
            }
        }
    }

    private void Update()
    {
        if (player != null && playerScript.puzzleActive == false)
        {
            if(player.position.x - transform.position.x > 15){
                chaseSpeed = 3f;
            } else{
                chaseSpeed = 1.5f;
            }
            timer += Time.deltaTime;
            if(timer > waitTime){
            // Calculate direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Force the character to only move right (positive x-axis direction)
            direction = Vector3.right;

            // Move Fake Elon Musk towards the player using a constant speed
            transform.position += direction * chaseSpeed * Time.deltaTime * playerScript.multiplier/1.5f;

            // Calculate distance between Fake Elon Musk and the player
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // If the player is within the catch distance, perform catch action
            if (distanceToPlayer <= catchDistance)
            {
                GameManager.GameOver();
                // Perform catch action here (e.g., game over or capturing animation)
                Debug.Log("Fake Elon Musk caught the player!");
                // Add your own game over logic or any other actions when caught
            }
            }
        }
    }
}
