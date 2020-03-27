using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BulletDestroy : MonoBehaviour
{
    
    void Start(){
        Destroy(gameObject, 2);
    }
    void OnTriggerEnter2D(Collider2D collision){

        if(collision.tag == "Bullet" || collision.tag == "EnemyBullet"){
            return;
        }
        if(gameObject.tag == "Bullet"){
            if(collision.tag != "Player"){
                Destroy(gameObject);
            }
        } else if (gameObject.tag == "EnemyBullet"){
            if(collision.tag != "Enemy"){
                Destroy(gameObject);
            }
        }
    }
}
