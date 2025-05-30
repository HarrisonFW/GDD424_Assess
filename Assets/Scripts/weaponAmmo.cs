using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponAmmo : MonoBehaviour
{
    //Wow ChatGPT is getting alot of milage in this project amiright?

    public enum AmmoType { Shells, Needles}
    public AmmoType ammoType;

    public int currentAmmo = 0;
    public int maxAmmo = 10;

    public float reloadTime = 1f;

    public bool isReloading = false;


    public Image shotgunReload;
    public Sprite reload1;
    public Sprite reload2;
    public Sprite reload3;
    public float relaodTime = 0.15f;



    //This gets called before shooting
    public bool CanFire() // won't let the player fire if they either don't have ammunition or are currently reloading
    {
        return currentAmmo > 0 && !isReloading;
    }

    public void ConsumeAmmo() // omm nom nom eats the ammo
    {
        if (CanFire())
            currentAmmo--;
    }

    //Call this from pickups
    public void AddAmmo(int amount) //doesn't let ammo exceed a certain amount
    {
        currentAmmo = Mathf.Clamp(currentAmmo + amount, 0, maxAmmo);
    }

    public IEnumerator Reload() // handles the changing sprites for the shotguns reload animation
    {
        if (isReloading || currentAmmo == maxAmmo)
            yield break;

        isReloading = true;

        shotgunReload.sprite = reload1;

        yield return new WaitForSeconds(relaodTime);
        shotgunReload.sprite = reload2;

        yield return new WaitForSeconds(relaodTime);
        shotgunReload.sprite = reload3;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("Reload Complete");
    }
}
