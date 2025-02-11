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
        var damage = Random.Range(damageRange.x, damageRange.y);
        //print($"Hit {other.gameObject} for {damage} damage");
        DamageIndicatorManager.instance.ShowDamageIndicator((int)damage, transform.position);
        
        var enemy = other.gameObject.GetComponent<Enemy>();
        if(enemy !=null) enemy.TakeDamage((int)damage);
        
        Destroy(gameObject);
    }
}
