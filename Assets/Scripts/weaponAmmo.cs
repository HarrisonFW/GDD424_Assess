using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponAmmo : MonoBehaviour
{
    //Wow ChatGPT is getting alot of milage in this project amiright?

    public enum AmmoType { Shells, Needles}
    public AmmoType ammoType;

    public int currentAmmo = 0;
    public int maxAmmo = 10;

    public float reloadTime = 1f;

    public bool isReloading = false;

    //This gets called before shooting
    public bool CanFire()
    {
        return currentAmmo > 0 && !isReloading;
    }

    public void ConsumeAmmo()
    {
        if (CanFire())
            currentAmmo--;
    }

    //Call this from pickups
    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + amount, 0, maxAmmo);
    }

    public IEnumerator Reload()
    {
        if (isReloading || currentAmmo == maxAmmo)
            yield break;

        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("Reload Complete");
    }
}
