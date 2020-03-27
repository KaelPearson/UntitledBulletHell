using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerShoot : NetworkBehaviour
{
    public GameObject bullet;
    public float speed = 2;

    float timer = 0;
    public float delayBetweenBullets = 1;

    void Start()
    {

    }


    [Command]
    void CmdFire(Vector2 shootDirection, Vector3 tranPos){
        RpcFire(shootDirection, tranPos);
    }
    
    [ClientRpc]
    void RpcFire(Vector2 shootDirection, Vector3 tranPos){

        // Create bullet on player
        GameObject bulletInstance = Instantiate(bullet, tranPos, Quaternion.Euler(new Vector3(0,0,0)));

        // Position of bullet becomes normalized to make same speed everywhere
        Vector2 pos = new Vector2(shootDirection.x, shootDirection.y).normalized;

        // Adds force as a impulse
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(pos * speed, ForceMode2D.Impulse);

        // Spawns on server as well
        NetworkServer.Spawn(bulletInstance);
    }
    void fire(){
        // Gets MousePos and sets the Z to 0 because 2d field
        Vector3 shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;

        // Transforms from screen space to world space then direction is adjusted due to player position
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        CmdFire(shootDirection, transform.position);
    }

    void Update()
    {
        if(!base.isLocalPlayer){
            return;
        }

        if (Input.GetMouseButton(0) && timer >= delayBetweenBullets) {
            fire();
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
