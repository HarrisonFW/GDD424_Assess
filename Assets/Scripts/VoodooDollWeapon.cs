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
    public float attackRange = 25f;
    public int damage = 5;
    public float attackCooldown = 0.5f;
    public float stabAnimDuration = 0.3f;
}
