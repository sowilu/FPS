using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;

    public float cooldown = 0.5f;
    public float reload = 3;

    public int magazineCapasity = 10;
    public int magazine;
    
    private bool canFire = true;
    
    void Start()
    {
        magazine = magazineCapasity;
    }

    void Update()
    {
        if (canFire && Input.GetMouseButtonDown(0))
        {
            if (magazine > 0)
            {
                magazine--;
                Instantiate(bulletPrefab, muzzle.position, transform.rotation);
                StartCoroutine(Cooldown());
            }
            else
            {
                StartCoroutine(Reload());
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
        
    }

    IEnumerator Reload()
    {
        canFire = false;
        transform.localRotation = Quaternion.Euler(90, 0, 0);
        yield return new WaitForSeconds(reload);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        magazine = magazineCapasity;
        canFire = true;
    }

    IEnumerator Cooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(cooldown);
        canFire = true;
    }
}
