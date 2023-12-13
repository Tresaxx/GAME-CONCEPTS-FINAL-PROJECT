using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject player;
    private GameObject p;
    public bool despawn = false;
    private float timer = 0.0f;
    private float despawnTimer = 0.0f;
    public float respawnTime = 10.0f;
    public float despawnTime = 5.0f;
    // Start is called before the first frame update
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > respawnTime && gameObject.tag != "PowerUp"){
            spawnPowerUp();
            timer = timer - respawnTime;
            despawn = true;
        } 
        if(despawn = true){
            despawnTimer += Time.deltaTime;
        }
        if(despawnTimer > despawnTime && gameObject.tag == "PowerUp"){
            Destroy(gameObject);
            despawn = true;
            despawnTimer -= despawnTime;
        } else if(despawnTimer > despawnTime){
            spawnPowerUp();
            despawnTimer -= despawnTime;
        }
    }

    private void spawnPowerUp(){
        if(player.transform.position.y < 0.0f){
            p = Instantiate(powerUp);
            p.transform.position = new Vector2(player.transform.position.x + 3, Random.Range(player.transform.position.y + 0.5f, 1.5f));
        }else{
            p = Instantiate(powerUp);
            p.transform.position = new Vector2(player.transform.position.x + 5, Random.Range(player.transform.position.y - 0.5f, 1.5f));
        }
    }
}
