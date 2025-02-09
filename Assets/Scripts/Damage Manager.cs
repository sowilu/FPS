using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager instance;
    
    public GameObject damagePrefab;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    public void ShowDamage(int damage, Vector3 position)
    {
        var indicator = Instantiate(damagePrefab, position, Quaternion.identity);
        indicator.GetComponent<DamageIndicator>().SetDamage(damage);
    }
}
