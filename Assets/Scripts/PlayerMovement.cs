using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour {
    Rigidbody2D rb;
    public float movementSpeed = 5;

    void Start() {
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
        rb.MovePosition(pos);
    }
}