using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float lifeTime = 3;
    public Vector2 damageRange = new Vector2(10, 20);

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        //todo: check for health
        print($"Bullet Hit: {other.gameObject.name}, dealt: {Random.Range(-damageRange.x, damageRange.x)}");
    }
}
