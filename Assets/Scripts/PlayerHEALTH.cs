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
        }
    }
}
