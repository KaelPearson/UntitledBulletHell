using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{


    public int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Bullet"){
            health--;
            if(health == 0){
                Destroy(gameObject, 0.2f);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
