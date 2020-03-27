using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour {
    Rigidbody2D rb;
    public float movementSpeed = 5;

    public float delayRoll = 3;
    float timer;
    
    void Start() {
        timer = delayRoll;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(!base.isLocalPlayer){
            return;
        }
        Vector3 pos = transform.position;

        if (Input.GetKey("w")) {
            pos.y += movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s")) {
            pos.y -= movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d")) {
            pos.x += movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a")) {
            pos.x -= movementSpeed * Time.deltaTime;
        }
        if(Input.GetKeyDown("space") && timer >= delayRoll){
            
            if (Input.GetKey("w")) {
                pos.y += movementSpeed * Time.deltaTime * 7;
            }
            if (Input.GetKey("s")) {
                pos.y -= movementSpeed * Time.deltaTime * 7;
            }
            if (Input.GetKey("d")) {
                pos.x += movementSpeed * Time.deltaTime * 7;
            }
            if (Input.GetKey("a")) {
                pos.x -= movementSpeed * Time.deltaTime * 7;
            }
            
        }
        rb.MovePosition(pos);
        timer += Time.deltaTime;
    }
}