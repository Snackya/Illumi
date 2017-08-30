﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {

    public Transform slingshot;

    private int dmgEnemy = 45;
    private int dmgBasilisk = 15;
    private int dmgBlackKnight = 10;
    private int dmgBeehive = 10;
    private int dmgPillar = 25;
    private int dmgDeacon = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject.name == "Arrow(Clone)")
            {
                Destroy(other.gameObject);
            }
            if (other.gameObject.name == "HolyArrow(Clone)")
            {
                Destroy(other.gameObject);
            }
            else if(other.gameObject.name != "Boulder(Clone)")
            {
                other.gameObject.GetComponent<EnemyHealth>().health.CurrentVal -= dmgEnemy;
                other.gameObject.GetComponent<EnemyAI>().Knockback();
            }
        }

        if (other.gameObject.tag == "Pillar")
        {
            other.gameObject.GetComponent<EnemyHealth>().health.CurrentVal -= dmgPillar;
        }

        if (other.gameObject.tag == "Basilisk")
        {
            if (other.gameObject.name.Contains("BasiliskScream"))
            {
                Destroy(other.gameObject);
            }
            else if (other.gameObject.name == "Headbutt")
            {
                
            }
            else
            {
                other.gameObject.GetComponent<EnemyHealth>().health.CurrentVal -= dmgBasilisk;
            }
        }
        if (other.gameObject.tag == "BlackKnight")
        {
            if (other.gameObject.name == "BlackKnight")
            {
                other.gameObject.GetComponent<EnemyHealth>().health.CurrentVal -= dmgBlackKnight;
            }
        }
        if (other.gameObject.name == "Beehive")
        {
            other.gameObject.GetComponent<EnemyHealth>().health.CurrentVal -= dmgBeehive;
        }
        if (other.gameObject.tag == "Bee")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Deacon")
        {
            other.gameObject.GetComponent<EnemyHealth>().health.CurrentVal -= dmgDeacon;
        }

        //knock boulders back and re-define them as player weapons
        if (other.gameObject.name.Contains("Boulder"))
        {
            GameObject boulder = other.gameObject;
            ProjectileController projCtrl = other.gameObject.GetComponent<ProjectileController>();

            projCtrl.direction = (slingshot.position - boulder.transform.position).normalized * projCtrl.speed;
            projCtrl.rotation *= -1;    //invert rotation
            projCtrl.lifetime = projCtrl.maxLifetime;   //reset lifetime
            boulder.tag = "PlayerWeapon";
        }
    }
}
