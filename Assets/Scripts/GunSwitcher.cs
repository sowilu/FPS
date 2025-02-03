using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    public GameObject[] guns;

    private int index = 0;
    
    void Start()
    {
        SwitchGun(0);
    }

    
    void Update()
    {
        var scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheel > 0)
        {
            SwitchGun((index + 1) % guns.Length);
        }
        else if (scrollWheel < 0)
        {
            var i = index - 1;
            if(i < 0) i = guns.Length - 1;
            SwitchGun(i);
        }
    }

    void SwitchGun(int newIndex)
    {
        guns[index].SetActive(false);
        guns[newIndex].SetActive(true);
        index = newIndex;
    }
}
