using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public Transform cameraPosistion;

    // Update is called once per frame
    void Update() // not much here is there
    {
        transform.position = cameraPosistion.position;
    }
}
