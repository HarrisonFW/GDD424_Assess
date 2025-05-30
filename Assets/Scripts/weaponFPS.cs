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


    

    private void OnEnable() //immidielty enable shooting
    {
        canShoot = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<weaponAmmo>();
    }

    // Update is called once per frame
    void Update() // code for recognising mouse inputs and calls the Shoot coroutine
    {
        if (ammo == null) return;

        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            if (ammo.CanFire())
            {
                //Couroutine is called here to process rest of firing stuff
                StartCoroutine(Shoot());
                Debug.Log("Firing!");

                ammo.ConsumeAmmo();
            }
            else if(!ammo.isReloading)
            {
                Debug.Log("Out of ammo! Press R to reload");
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ammo.Reload());

        }
    }

    

    private IEnumerator Shoot() // can't shoot while shooting, hence why it's momentarily disabled. Also processes the cooldown time
    {
        canShoot = false;

        ProcessRaycast();

        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }

    private void ProcessRaycast() // Raycasting a line and makes a weapon damage an enemy
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
    

