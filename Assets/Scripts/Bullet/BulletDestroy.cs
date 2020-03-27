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

        if(gameObject.tag == "Bullet"){
            if(collision.tag != "Player" && collision.tag != "Bullet"){
                Destroy(gameObject);
            }
        } else if (gameObject.tag == "EnemyBullet"){
            if(collision.tag != "Enemy" && collision.tag != "EnemyBullet"){
                Destroy(gameObject);
            }
        }
    }
}
