using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Gun {
    private string name;
    private int damage;
    private float fireRate;
    private int magazine;
    public Gun(string name, int damage, float fireRate, int magazine){
        this.name = name;
        this.damage = damage;
        this.fireRate = fireRate;
        this.magazine = magazine;
    }
    public string getName(){
        return name;
    }
    public int getDamage(){
        return damage;
    }
    public float getFireRate(){
        return fireRate;
    }
    public int getMagazine(){
        return magazine;
    }
}