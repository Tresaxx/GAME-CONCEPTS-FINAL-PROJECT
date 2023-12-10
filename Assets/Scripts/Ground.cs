using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    Player player;

    public float groundHeight;
    public float groundRight;
    public float screenRight;
    BoxCollider2D collider;

    bool didGenerateGround = false;

    private void Awake(){
        player = GameObject.Find("Player").GetComponent<Player>();
        
        collider = GetComponent<BoxCollider2D>();
        groundHeight = transform.position.y + (collider.size.y/2);
        screenRight = Camera.main.transform.position.x * 2;
    }

    private void FixedUpdate(){
        Debug.Log("Screen " + screenRight);
        Debug.Log("Ground " + groundRight);

        Vector2 pos = transform.position;

        
        groundRight = transform.position.x + (collider.size.x / 2);
        
        if(groundRight < 0){
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
        pos.x = screenRight + 1;
        pos.y = transform.position.y;
        go.transform.position = pos;
    }
}
