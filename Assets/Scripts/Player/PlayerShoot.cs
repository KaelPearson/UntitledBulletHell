using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Threading;
using UnityEngine.UI;
public class PlayerShoot : NetworkBehaviour
{
    public GameObject bullet;
    public float speed = 2;
    public Text reloadCount;
    float timer = 0;
    float delayBetweenBullets = 1;
    float damage = 0;
    float magazine = 0;
    float currentMag = 0;
    public List<Gun> gunList = new List<Gun>(); 
    void Start()
    {
        Gun Pistol = new Gun("Pistol", 25, 1f, 6);
        gunList.Add(Pistol);
        Gun AR = new Gun("AR", 10, 0.1f, 30);
        gunList.Add(AR);
        newGun(AR);
    }

    void newGun(Gun gun){
        PlayerStats.Gun = gun.getName();
        delayBetweenBullets = gun.getFireRate();
        damage = gun.getDamage();
        magazine = gun.getMagazine();
        currentMag = magazine;
        reloadCount.text = "Bullets: " + currentMag + " / " + magazine;
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
    bool reloading = false;
    IEnumerator reload(){
        reloading = true;
        reloadCount.text = "Reloading...";
        yield return new WaitForSeconds(5.0f);
        reloading = false;
        currentMag = magazine;
        reloadCount.text = "Bullets: " + currentMag + " / " + magazine;
    }
    void Update()
    {
        if(!base.isLocalPlayer){
            return;
        }
        if (Input.GetMouseButton(0) && timer >= delayBetweenBullets && currentMag != 0) {
            fire();
            currentMag--;
            reloadCount.text = "Bullets: " + currentMag + " / " + magazine;
            timer = 0;
        } else if (currentMag == 0 && reloading != true){
            StartCoroutine(reload());
        }
        timer += Time.deltaTime;
    }
}
