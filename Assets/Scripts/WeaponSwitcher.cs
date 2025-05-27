using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponSwitcher : MonoBehaviour
{
    //Thanks ChatGPT


    public GameObject[] weapons;
    private int currentWeaponIndex = 0;

    void Start()
    {
        SelectWeapon(currentWeaponIndex);
    }

    void Update()
    {
        HandleScrollInput();
        HandleNumberKeyInput();
    }

    void HandleScrollInput()
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

    void HandleNumberKeyInput()
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

    void SelectWeapon(int index)
    {
        currentWeaponIndex = index;

        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == currentWeaponIndex);
        }

        Debug.Log("Switched to weapon: " + weapons[index].name);
    }
}


