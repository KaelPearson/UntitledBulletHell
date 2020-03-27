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
    void CmdFire(){

        // Gets MousePos and sets the Z to 0 because 2d field
        Vector3 shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;

        // Transforms from screen space to world space 
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);

        // Create bullet on player
        GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0)));

        // Position of bullet becomes normalized to make same speed everywhere
        Vector2 pos = new Vector2(shootDirection.x, shootDirection.y).normalized;
        pos *= speed;
        // Adds force as a impulse
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(pos, ForceMode2D.Impulse);

        // Spawns on server as well
        NetworkServer.Spawn(bulletInstance);

        timer = 0;
    }

    void Update()
    {
        if(!base.isLocalPlayer){
            return;
        }

        if (Input.GetMouseButton(0) && timer >= delayBetweenBullets) {
            CmdFire();
        }
        timer += Time.deltaTime;
    }
}
