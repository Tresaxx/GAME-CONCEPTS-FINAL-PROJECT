using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject player;
    public float respawnTime = 20.0f;
    public float currentPowerUp = 1;
    public float maxPowerUp = 2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(powerUpLoop());
    }
    private void spawnPowerUp(){
        if(currentPowerUp <= maxPowerUp){
            GameObject p = Instantiate(powerUp);
            p.transform.position = new Vector2(player.transform.position.x + 2, Random.Range(player.transform.position.y, player.transform.position.y + 2));
            currentPowerUp++;
        }
    }

    IEnumerator powerUpLoop(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnPowerUp();
        }
    }

    public void DestroyGameObject(){
        Destroy(gameObject);
    }
}
