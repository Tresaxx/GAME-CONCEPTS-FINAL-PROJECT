using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject player;
    public Player playerScript;
    public FakeElonMusk elon;
    public float groundHeight;
    public float groundRight;
    public float screenRight;
    BoxCollider2D collider;

    bool didGenerateGround = false;

    private void Awake(){
        collider = GetComponent<BoxCollider2D>();
        groundHeight = transform.position.y + (collider.size.y/2);
    }

    private void Update(){

        screenRight = player.transform.position.x * 2;
        Vector2 pos = transform.position;

        
        groundRight = transform.position.x + collider.size.x;
        
        if(groundRight < elon.transform.position.x){
            Destroy(gameObject);
            return;
        }

        if(!didGenerateGround){
            if(groundRight < screenRight){
                didGenerateGround = true;
                generateGround();
            }
        }
    }

    void generateGround(){
        GameObject go = Instantiate(gameObject);
        BoxCollider2D goCollider = go.GetComponent<BoxCollider2D>();
        Vector2 pos;
        pos.x = screenRight + 4.5f + playerScript.speed;
        pos.y = Random.Range(0, 2);
        go.transform.position = pos;
    }
}
