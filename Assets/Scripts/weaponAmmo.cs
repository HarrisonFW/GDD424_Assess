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

    //This gets called before shooting
    public bool CanFire()
    {
        return currentAmmo > 0;
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
}
