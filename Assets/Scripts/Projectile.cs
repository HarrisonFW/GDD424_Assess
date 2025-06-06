﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;
    public float lifetime = 5f;

    public void Start()
    {
        Destroy(gameObject, lifetime); // in case bullet projectile doesn't hit anything
    }

    public void OnTriggerEnter(Collider other) //checks if the bullet hits the player and makes them take damage, also destroys the bullet
    {
        if (other.CompareTag("Player"))
        {
            PlayerHEALTH health = other.GetComponent<PlayerHEALTH>();
            if (health)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

}
