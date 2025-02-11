using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float cooldown = 0.2f;
    public float reload = 3;
    
    public Transform muzzle;
    public GameObject bulletPrefab;
    
    public int magazineCapacity = 20;
    public int magazine;
    
    private bool canFire = true;
    
    void Start()
    {
        magazine = magazineCapacity;
    }

    void Update()
    {
        if (magazine > 0 && canFire && Input.GetMouseButtonDown(0))
        {
            magazine--;
            var bullet = Instantiate(bulletPrefab, muzzle.position, transform.rotation);
            
            var screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            var ray = Camera.main.ScreenPointToRay(screenCenter);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                bullet.transform.LookAt(hit.point);
            }
            
            
            StartCoroutine(Cooldown());
        }
        else if (magazine == 0 && canFire && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Reload());
        }

        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Cooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(cooldown);
        canFire = true;
    }

    IEnumerator Reload()
    {
        canFire = false;
        transform.localRotation = Quaternion.Euler(90, 0, 0);
        yield return new WaitForSeconds(reload);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        magazine = magazineCapacity;
        canFire = true;
    }
    
}
