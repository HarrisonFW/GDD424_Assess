using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHEALTH : MonoBehaviour
{
    float hP = 100f;

    private void Update()
    {
        print(hP);
    }

    public void TakeDamage(float enemyBullets)
    {
        hP -= enemyBullets;
        if(hP <= 0)
        {
            Time.timeScale = 0;
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player died! wow you freaking suck");
        GameObject.FindObjectOfType<GameManager>().PlayerDied();
    }

    public void HealToFull()
    {
        //currentHealth = maxHealth;
        //UpdateHealthUI();
    }
}
