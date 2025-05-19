using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shotgunUIController : MonoBehaviour
{
    //Thank you ChatGPT for this code

    public Image shotgunImage;

    public Sprite shotgunIdle;
    public Sprite shotgunFire1;
    public Sprite shotgunFire2;
    public float fireDisplayTime = 0.15f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FireShotgun());
        }
    }

    IEnumerator FireShotgun()
    {
        shotgunImage.sprite = shotgunFire1;

        yield return new WaitForSeconds(fireDisplayTime);
        shotgunImage.sprite = shotgunFire2;

        yield return new WaitForSeconds(fireDisplayTime);
        shotgunImage.sprite = shotgunIdle;

    }
}
