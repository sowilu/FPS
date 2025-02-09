using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicatorManager : MonoBehaviour
{
    public static DamageIndicatorManager instance;

    public GameObject damageIndicator;
    
    private void Awake()
    {
        if(instance == null) instance = this;
    }

    public void ShowDamageIndicator(int damage, Vector3 position)
    {
        var d = Instantiate(damageIndicator, position, Quaternion.identity);
        d.GetComponent<DamageIndicator>().SetDamage(damage);
    }
}
