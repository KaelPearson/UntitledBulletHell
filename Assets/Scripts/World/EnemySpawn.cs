using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemySpawn : NetworkBehaviour
{
    public GameObject enemy;
    public float timer = 0;
    public float spawnTimer = 10;

    [ClientRpc]
    void RpcSpawnEnemy(Vector3 pos){
        GameObject enemyInstance = Instantiate(enemy, pos, Quaternion.Euler(new Vector3(0,0,0)));
        NetworkServer.Spawn(enemyInstance);
    }
    void spawnEnemy(){
        int rand = Random.Range(1,4);
        Vector3 pos = new Vector3();

        switch(rand){
            case 1:
                pos[0] = -2;
                pos[1] = 3;
                break;
            case 2:
                pos[0] = -2;
                pos[1] = 3;
                break;
            case 3:
                pos[0] = -2;
                pos[1] = 3;
                break;
            case 4:
                pos[0] = -2;
                pos[1] = 3;
                break;
        }
        RpcSpawnEnemy(pos);
    }
    void Update() {
        if(timer >= spawnTimer){
            spawnEnemy();
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
