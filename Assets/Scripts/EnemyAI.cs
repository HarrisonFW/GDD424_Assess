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

    //sprite components here
    public Sprite idleSprite;
    public Sprite firingSprite;
    public float preFireDelay = 0.2f; //time between changing to the new sprte and shooting
    private SpriteRenderer spriteRenderer;


    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer) spriteRenderer.sprite = idleSprite;


    }

    public void Update() //at a moment to moment basis, checks how far the player is and either persues the player or once it's within range, starts shooting the player
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
            agent.ResetPath();

            transform.LookAt(player);



            if(Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void Shoot()  //enemy still shoots but the changing of its sprite doesn't function.
    {
        StartCoroutine(FireWithWindup());
    }

    IEnumerator FireWithWindup() // this code is supposed to change the enemies sprite to an "attack sprite" but doesn't work despite no errors being present.
    {
        if (spriteRenderer)
            spriteRenderer.sprite = firingSprite;

        yield return new WaitForSeconds(preFireDelay);

        // Spawn the projectile
        GameObject proj = Instantiate(projectilePrefab, firePointForBullet.position, firePointForBullet.rotation);
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.velocity = (player.position - firePointForBullet.position).normalized * projectileSpeed;
        }

        Projectile projectileScript = proj.GetComponent<Projectile>();
        if (projectileScript)
        {
            projectileScript.damage = damage;
        }

        // Return to idle sprite
        if (spriteRenderer)
            spriteRenderer.sprite = idleSprite;
    }

}
