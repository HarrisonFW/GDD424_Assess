using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoodooDollWeapon : MonoBehaviour
{
    [Header("Sprites")]

    public Sprite idleSprite;
    public Sprite stabSprite1;
    public Sprite stabSprite2;


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

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleSprite;
    }

    public void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
        }

        if (isAttacking)
        {
            HandleStabAnimation();
        }
    }

    public void Attack()
    {
        lastAttackTime = Time.time;
        isAttacking = true;
        stabAnimTimer = 0f;
        stabSpriteToggle = false;

        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, attackRange, enemyLayer);

        Debug.DrawRay(firePoint.position, firePoint.right * attackRange, Color.red, 1f); // <--- remove later when fixed

        if(hit.collider != null)
        {
            //Hit enemy
            Debug.Log("Hit: " + hit.collider.name);
            EnemyHEALTH enemy = hit.collider.GetComponent<EnemyHEALTH>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        else
        {
            Debug.Log("No enemy Hit! Damaging Player.");
            playerHealth.TakeDamage(damage);
        }
    }

    public void HandleStabAnimation()
    {
        stabAnimTimer += Time.deltaTime;

        //Switch sprite halfway through the animation stabbing effect

        if(stabAnimTimer < stabAnimDuration / 2f)
        {
            spriteRenderer.sprite = stabSprite1;
        }

        else if (stabAnimTimer < stabAnimDuration)
        {
            spriteRenderer.sprite = stabSprite2;
        }
        else
        {
            //Animation finsihed, back to the idle animation
            spriteRenderer.sprite = idleSprite;
            isAttacking = false;
        }
    }

}
