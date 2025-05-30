using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponAmmoUI : MonoBehaviour
{
    public weaponAmmo weaponAmmoButLikeNotTheScript;
    public TMP_Text ammoText;

    public void Update() // updates the displayed ammo amount for the shotgun. 
    {
        if (weaponAmmoButLikeNotTheScript != null && ammoText != null)
        {
            ammoText.text = weaponAmmoButLikeNotTheScript.currentAmmo + " / " + weaponAmmoButLikeNotTheScript.maxAmmo;
        }
    }
}
