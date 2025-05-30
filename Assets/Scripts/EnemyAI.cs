using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //gonna be graduating with my guy ChatGPT by the end of this
    //Suffice to say I am still the one typing all this out, not blindly copy pasting

    public Transform player;
    public float chaseRange = 15f;
    public float shootingRange = 10f;
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePointForBullet;
    public float projectileSpeed = 25f;
    public float damage = 10f;

    private NavMeshAgent agent;
    private float nextFireTime;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        if (!player) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if(distance > chaseRange)
        {
            agent.isStopped = true;
            return;
        }

        if (distance > shootingRange)
        {
            //Chase the player
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            //stop moving and begin shooting
            agent.isStopped = true;
            transform.LookAt(player);

            if(Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    public void Shoot()
    {
        GameObject proj = Instantiate(projectilePrefab, firePointForBullet.position, firePointForBullet.rotation);
        Rigidbody rb = proj.GetComponent<Rigidbody>();

        if (rb)
        {
            rb.velocity = (player.position - firePointForBullet.position).normalized * projectileSpeed;
        }

        //remeber create projectile script
        Projectile projectileScript = proj.GetComponent<Projectile>();
        if (projectileScript)
        {
            projectileScript.damage = damage;
        }
    }

}
