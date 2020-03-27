using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class PlayerHealth : NetworkBehaviour
{
    public int health = 5;
    public Slider slider;

    void Start()
    {
        slider.value = health;
        if(base.isLocalPlayer){
            return;
        }
        slider.gameObject.SetActive(false);
    }
    [Command]
    void CmdDeletePlayer(GameObject player){
        Destroy(player);
    }
    void OnTriggerEnter2D(Collider2D collision){
        
        if(!base.isLocalPlayer){
            return;
        }
        if(collision.tag == "EnemyBullet"){
            health--;
            slider.value = health;
            if(health <= 0){
                CmdDeletePlayer(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
