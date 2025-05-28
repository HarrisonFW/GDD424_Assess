using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponFPS : MonoBehaviour
{
    [SerializeField] Camera originPos;

   // [SerializeField] Ammo ammo;
   // [SerializeField] AmmoType ammoType;

    [SerializeField] float weaponRange;
    [SerializeField] float weaponDamage;
    [SerializeField] float cooldownTime = 0.1f;

    bool canShoot = true;

    private weaponAmmo ammo;

    private void OnEnable()
    {
        canShoot = true;
    }






    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<weaponAmmo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            if (ammo != null && ammo.CanFire())
            {
                //Couroutine is called here to process rest of firing stuff
                StartCoroutine(Shoot());
                Debug.Log("Firing!");

                ammo.ConsumeAmmo();
            }
            else
            {
                Debug.Log("Out of ammo!");
            }
            
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        ProcessRaycast();

        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if(Physics.Raycast(originPos.transform.position, originPos.transform.forward, out hit, weaponRange))
        {
            EnemyHEALTH enemyHealth = hit.transform.GetComponent<EnemyHEALTH>();
            if (enemyHealth == null)
            {
                return;
            }
            enemyHealth.TakeDamage(weaponDamage);
        }

        else
        {
            return;
        }
    }

    
}
    

