using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject player;
    private Player playerScript;
    private GameObject p;
    public bool despawn = false;
    private float timer = 0.0f;
    private float despawnTimer = 0.0f;
    public float respawnTime = 10.0f;
    public float despawnTime = 5.0f;
    // Start is called before the first frame update
    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > respawnTime && gameObject.tag != "PowerUp" && gameObject.tag != "Puzzle"){
            spawnPowerUp();
            timer = timer - respawnTime;
            despawn = true;
        } 
        if(despawn == true){
            despawnTimer += Time.deltaTime;
        }
        if(despawnTimer > despawnTime && gameObject.tag == "PowerUp"){
            Destroy(gameObject);
            despawn = false;
            despawnTimer -= despawnTime;
        }else if(despawnTimer > despawnTime && gameObject.tag != "Puzzle"){
            spawnPuzzle();
            despawnTimer -= despawnTime;
        }
        if(despawnTimer > despawnTime && gameObject.tag == "Puzzle"){
            Destroy(gameObject);
            despawnTimer -= despawnTime;
        }
    }

    private void spawnPowerUp(){
        p = Instantiate(powerUp);
        p.transform.position = new Vector2(Random.Range(player.transform.position.x + 3 * playerScript.speed, player.transform.position.x + 7 * playerScript.speed), Random.Range(0.0f, 1.5f));
    }

    private void spawnPuzzle(){
        p = Instantiate(powerUp);
        p.transform.position = new Vector2(Random.Range(player.transform.position.x + 3 * playerScript.speed, player.transform.position.x + 7 * playerScript.speed), Random.Range(0.0f, 1.0f));
    }
}
