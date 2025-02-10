using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform muzzle;
    public Transform cam;
    
    public GameObject bulletPrefab;
    
    public float cooldown = 0.3f;
    public float reload = 0.5f;
    
    public int magazineCapasity = 6;
    public int currentAmmo = 6;

    private bool canShoot = true;


    void Update()
    {
        if (currentAmmo > 0 && canShoot && Input.GetMouseButtonDown(0))
        {
            //create bullet
            currentAmmo--;
            var bullet = Instantiate(bulletPrefab, muzzle.position, cam.rotation);
            
            //raycast for target
            var screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            var ray = Camera.main.ScreenPointToRay(screenCenter);

            if (Physics.Raycast(ray, out var hit))
            {
                //rotate bullet towards target
                bullet.transform.LookAt(hit.point);
            }
            
            StartCoroutine(Cooldown());
        }
        else if (currentAmmo == 0 && canShoot && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Reload());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }

    IEnumerator Reload()
    {
        canShoot = false;
        //todo: play reload animation
        transform.localRotation = Quaternion.Euler(90, 0, 0);
        yield return new WaitForSeconds(reload);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        currentAmmo = magazineCapasity;
        canShoot = true;
    }
}
