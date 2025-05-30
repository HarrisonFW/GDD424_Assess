using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHEALTH : MonoBehaviour
{
   public float hP = 100f;

   public WaveManager waveManager; 

    bool isDead = false;

    //thank you ChatGPT for the changing sprite code

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

    public void Update() //forces the sprites to look at the player at a moment to moment basis
    {

        transform.LookAt(player.transform);

        //FacePlayer();

        if (hurtTimer > 0)
        {
            hurtTimer -= Time.deltaTime;
            if (hurtTimer <= 0 && idleSprite != null)
                spriteRenderer.sprite = idleSprite;
        }
    }



    

    public void TakeDamage(float weaponDamage) // works on the enemy changing to its hurt sprite when damaged by either of the weapons, also calls the "Die" function here
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

            Die();

            spriteRenderer.sprite = deadSprite;
            Destroy(gameObject);
            //GetComponent<Animator>().SetTrigger("dyingTrigger");
        }
    }


    void Die() //enemy gets destroyed on death and the wave manager is notified so a new wave can start
    {
        if(waveManager != null)
        {
            waveManager.OnEnemyKilled();
        }

        Destroy(gameObject);
    }

}
