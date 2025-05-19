using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHEALTH : MonoBehaviour
{
    float hP = 100f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float weaponDamage)
    {
        BroadcastMessage("OnDamageTaken");
        hP -= weaponDamage;
        if(hP <= 0)
        {
            if (isDead) { return; }
            isDead = true;
            //GetComponent<Animator>().SetTrigger("dyingTrigger");
        }
    }
}
