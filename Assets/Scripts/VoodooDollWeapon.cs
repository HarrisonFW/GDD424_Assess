﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoodooDollWeapon : MonoBehaviour
{
   //You know 'em you love 'em, ChatGPT

    [Header("Attack Settings")]
    public float attackRange = 100f;
    public int damage = 5;
    public float attackCooldown = 0.5f;
    public float stabAnimDuration = 0.3f;

    [Header("References")]
    public Transform firePoint;
    public LayerMask enemyLayer;
    public PlayerHEALTH playerHealth; //This is a bit confusing

    private SpriteRenderer spriteRenderer;

    private float lastAttackTime = -999f;
    private bool isAttacking = false;
    private float stabAnimTimer = 0f;
    private bool stabSpriteToggle = false;

    private weaponAmmo ammo;

    public void Start()
    {
        ammo = GetComponent<weaponAmmo>();
    }

    public void Update() // allows the voodoo doll to "fire" after pressing down the mouse button, also has an attack cooldown
    {
        if(Input.GetButtonDown("Fire1") && Time.time >= lastAttackTime + attackCooldown)
        {
            if(ammo != null && ammo.CanFire())
            {
                //Only goes through with the Attack() if has ammo
                Attack();
                Debug.Log("Firing VoodooDoll");
                ammo.ConsumeAmmo();
            }
            else
            {
                Debug.Log("Out of Needles");
            }

            
        }

        if (isAttacking)
        {
            //HandleStabAnimation();
        }
    }

    public void Attack() //basically acts as a small damaging long range "gun" with the use of raycasting. Lots of debugging code used here
    {
       
            lastAttackTime = Time.time;
            isAttacking = true;
            stabAnimTimer = 0f;
            stabSpriteToggle = false;

            // Visualize the ray in the Scene view
            Debug.DrawRay(firePoint.position, firePoint.forward * attackRange, Color.red, 1f);

            // Use Physics.Raycast (3D)
            Ray ray = new Ray(firePoint.position, firePoint.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
            {
                Debug.Log("Raycast hit: " + hit.collider.name);

                EnemyHEALTH enemy = hit.collider.GetComponentInParent<EnemyHEALTH>();

                if (enemy != null)
                {
                    Debug.Log("EnemyHealth found! Dealing damage.");
                    enemy.TakeDamage(damage);
                }
                else
                {
                    Debug.LogWarning("Hit object has no EnemyHealth component.");
                }
            }
            else
            {
                Debug.Log("Raycast missed. Damaging player.");
                playerHealth.TakeDamage(damage);
            }
        

    }

  

}
