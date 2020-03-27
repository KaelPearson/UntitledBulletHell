using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class EnemyShoot : NetworkBehaviour
{

    public float shootDelay = 1.5f;
    float timer = 0;
    public GameObject bullet;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float getPlayerDistance(GameObject player){
        float distance = 0;
        // Get pos of char
        float x = Mathf.Abs(transform.position.x);
        float y = Mathf.Abs(transform.position.y);

        float playerx = Mathf.Abs(player.transform.position.x);
        float playery = Mathf.Abs(player.transform.position.y);

        distance = x + y;
        distance -= playerx + playery;
        
        return Mathf.Abs(distance);
    }
    GameObject findNearestPlayer(GameObject[] players){
        if(players == null){
            return null;
        }

        GameObject player = null;

        float bestDistance = 0;
        for(int i = 0; i < players.Length; i++){
            float distance = getPlayerDistance(players[i]);

            if(player == null){
                bestDistance = distance;
                player = players[i];
            } else if(bestDistance > distance){
                bestDistance = distance;
                player = players[i];
            }
        }
        return player;
    }

    
    [ClientRpc]
    void RpcFire(Vector2 shootDirection, Vector3 tranPos){
        // Create bullet on player
        GameObject bulletInstance = Instantiate(bullet, tranPos, Quaternion.Euler(new Vector3(0,0,0)));

        // Position of bullet becomes normalized to make same speed everywhere
        Vector2 pos = new Vector2(shootDirection.x, shootDirection.y).normalized;

        // Adds force as a impulse
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(pos * speed, ForceMode2D.Impulse);
        bulletInstance.tag = "EnemyBullet";
        // Spawns on server as well
        NetworkServer.Spawn(bulletInstance);
    }
    void fire(GameObject player){
        Vector2 shootDirection = new Vector2();
        shootDirection[0] = player.transform.position.x - transform.position.x;
        shootDirection[1] = player.transform.position.y - transform.position.y; 
        
        RpcFire(shootDirection, transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        GameObject closetPlayer = findNearestPlayer(players);

        Debug.Log(closetPlayer);

        if(timer >= shootDelay){
            if(closetPlayer != null && getPlayerDistance(closetPlayer) < 10){
                fire(closetPlayer);
                timer = 0;
            }
        }
        timer += Time.deltaTime;
    }
}
