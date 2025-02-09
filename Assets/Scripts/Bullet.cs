using UnityEngine;

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
        if (other.transform.CompareTag("Player")) return;
        
        //todo: deal damage
        //print($"Hit {other.gameObject.name} for {Random.Range(damageRange.x, damageRange.y)} damage");

        var damage = Random.Range(damageRange.x, damageRange.y);
        DamageIndicatorManager.instance.ShowDamageIndicator((int)damage, transform.position);
        
        Destroy(gameObject);
    }
}
