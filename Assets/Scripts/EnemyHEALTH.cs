using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHEALTH : MonoBehaviour
{
    float hP = 100f;

    bool isDead = false;

    [Header("Sprite Settings")]
    public Sprite idleSprite;
    public Sprite hurtSprite;
    public Sprite deadSprite;
    private SpriteRenderer spriteRenderer;

    [Header("Damage Feedback")]
    public float hurtDuration = 0.2f;
    private float hurtTimer = 0f;

    [Header("Player Reference")]
    private Transform player;

    public bool IsDead()
    {
        return isDead;
    }

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(idleSprite != null)
        {
            spriteRenderer.sprite = idleSprite;

            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
                player = playerObject.transform;
        }
    }

    public void Update()
    {
        //FacePlayer();

        if (hurtTimer > 0)
        {
            hurtTimer -= Time.deltaTime;
            if (hurtTimer <= 0 && idleSprite != null)
                spriteRenderer.sprite = idleSprite;
        }
    }

   // public void FacePlayer()
   // {
   //     if (player == null) return;
   //
   //     Vector3 direction = player.position - transform.position;
   //     float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
   //     transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
   // }

    public void TakeDamage(float weaponDamage)
    {
        BroadcastMessage("OnDamageTaken");
        hP -= weaponDamage;

        if(hurtSprite != null)
        {
            spriteRenderer.sprite = hurtSprite;
            hurtTimer = hurtDuration;
        }

        if(hP <= 0)
        {
            if (isDead) { return; }
            isDead = true;

            spriteRenderer.sprite = deadSprite;
            //Destroy(gameObject);
            //GetComponent<Animator>().SetTrigger("dyingTrigger");
        }
    }
}
