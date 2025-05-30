using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoodooUIController : MonoBehaviour
{
    public Image VoodooDollImage;

    public Sprite VoodooIdle;
    public Sprite VoodooStab1;
    public Sprite VoodooStab2;
    public float fireDisplayTime = 0.15f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FireShotgun());
        }
    }

    IEnumerator FireShotgun() // changes voodoo doll sprites when mosue button is pressed
    {
        VoodooDollImage.sprite = VoodooStab1;

        yield return new WaitForSeconds(fireDisplayTime);
        VoodooDollImage.sprite = VoodooStab2;

        yield return new WaitForSeconds(fireDisplayTime);
        VoodooDollImage.sprite = VoodooIdle;

    }
}
