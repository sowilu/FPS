using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float lifeTime = 3;
    public Vector2 damageRange = new Vector2(10, 20);
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        //print($"Hit {other.gameObject.name} for {Random.Range(damageRange.x, damageRange.y)}");
        var damage = Random.Range(damageRange.x, damageRange.y);
        DamageIndicator.instance.DisplayDamage((int)damage, transform.position);
        Destroy(gameObject);
    }
}
