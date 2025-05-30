using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shotgunUIController : MonoBehaviour
{
    public weaponAmmo shotgunAmmo;

    //Thank you ChatGPT for this code

    public Image shotgunImage;

    public Sprite shotgunIdle;
    public Sprite shotgunFire1;
    public Sprite shotgunFire2;
    public float fireDisplayTime = 0.15f;

    private bool isFiring = false;

    private void Update() //consumes ammo when fired and processes firing with clicking the mouse button
    {
        if (Input.GetButtonDown("Fire1") && !isFiring)
        {
            if(shotgunAmmo != null && shotgunAmmo.CanFire())
            {
                shotgunAmmo.ConsumeAmmo();
                StartCoroutine(FireShotgun());
            }
        }
        else
        {
            Debug.Log("No ammo- can't fire");
        }
    }

    IEnumerator FireShotgun() //shotgun firing sprites handleded here and are played in sequence
    {
        shotgunImage.sprite = shotgunFire1;

        yield return new WaitForSeconds(fireDisplayTime);
        shotgunImage.sprite = shotgunFire2;

        yield return new WaitForSeconds(fireDisplayTime);
        shotgunImage.sprite = shotgunIdle;

    }
}
