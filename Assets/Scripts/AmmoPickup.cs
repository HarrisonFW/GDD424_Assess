using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public weaponAmmo.AmmoType ammoType;
    public int ammoAmount = 5;

    public Transform player;

    private void OnTriggerEnter(Collider other) // when the player collided with the sprites, more ammo is added to each ones respective weapon. Redundant for the shotgun sicne the player can reload with R at any point, regardless of remainign ammo
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
