using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHEALTH : MonoBehaviour
{
    float hP = 100f;

    private void Update()
    {
        print(hP); //debugging since this isn't UI
    }

    public void TakeDamage(float enemyBullets) // function that pauses the game and calls the "Die" function once the players health reaches 0
    {
        hP -= enemyBullets;
        if(hP <= 0)
        {
            Time.timeScale = 0;
            Die();
        }
    }

    public void Die() //messages the debug console when the player dies
    {
        Debug.Log("Player died! wow you freaking suck");
        GameObject.FindObjectOfType<GameManager>().PlayerDied();
    }

    public void HealToFull() // unimplimented health regeneration
    {
        //currentHealth = maxHealth;
        //UpdateHealthUI();
    }
}
