using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D rb;
    float movementSpeed = 1;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        
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