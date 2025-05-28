using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public weaponAmmo.AmmoType ammoType;
    public int ammoAmount = 5;

    public Transform player;

    private void OnTriggerEnter(Collider other)
    {
        WeaponSwitcher switcher = other.GetComponentInChildren<WeaponSwitcher>();
        if (switcher == null) return;

        foreach (GameObject weapon in switcher.weapons)
        {
            weaponAmmo ammo = weapon.GetComponent<weaponAmmo>();
                if (ammo != null && ammo.ammoType == ammoType)
            {
                ammo.AddAmmo(ammoAmount);
            }

            Destroy(gameObject); // removes the pickup after it's collected
        }
    }

    private void Update()
    {
        transform.LookAt(player.transform); //so pickups always look at player, doesn't work for some reason
    }


}
