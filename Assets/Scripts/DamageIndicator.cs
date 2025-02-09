using UnityEngine;
using TMPro;

public class DamageIndicator : MonoBehaviour
{
    public TextMeshProUGUI damageText;
    public float lifetime = 1;
    public float speed = 2;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }

    public void SetDamage(int damage)
    {
        damageText.text = damage.ToString();
    }
}
