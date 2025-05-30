using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponSwitcher : MonoBehaviour
{
    //Thanks ChatGPT


    public GameObject[] weapons;
    private int currentWeaponIndex = 0;

    public GameObject[] weaponCanvases;

    void Start()
    {
        SelectWeapon(currentWeaponIndex);
    }

    void Update() // calls these fucntions continually
    {
        HandleScrollInput();
        HandleNumberKeyInput();
    }

    void HandleScrollInput() // since I like also using the scroll wheel to select weapons, this is the code for that, working if the user scrolls up or down
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
            SelectWeapon(currentWeaponIndex);
        }
        else if (scroll < 0f)
        {
            currentWeaponIndex = (currentWeaponIndex - 1 + weapons.Length) % weapons.Length;
            SelectWeapon(currentWeaponIndex);
        }
    }

    void HandleNumberKeyInput() // code for weapon selecting
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && weapons.Length > 1)
        {
            SelectWeapon(1);
        }
        // Add more keys if I add more weapons (Alpha3, Alpha4, etc.)
    }

    void SelectWeapon(int index) // code that would allow for easy exansion if more weapons were added instead of hard coding numbers
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            bool isActive = i == index;

            if (weapons[i] != null)
                weapons[i].SetActive(isActive);

            if (weaponCanvases[i] != null)
                weaponCanvases[i].SetActive(isActive);
        }
    }
}


