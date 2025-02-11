using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public Transform target;

    [Header("Attack settings")] 
    public int damage = 10;
    public float animationLength = 1.5f;
    public float cooldown = 0.5f;
    private bool isAttacking = false;
    
    
    private NavMeshAgent agent;
    private Animator animator;
    private int health;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (target != null && agent.enabled)
        {
            agent.SetDestination(target.position);
        }   
        var distance = Vector3.Distance(transform.position, target.position);
        
        animator.SetBool("isStopped", distance - agent.stoppingDistance <= 0.3f);

        if (distance - agent.stoppingDistance <= 0.3f && !isAttacking)
        {
            StartCoroutine(Attack());
        }
        
    }

    public void Die()
    {
        agent.enabled = false;
        animator.Play("Die");
        Destroy(this);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            return;
        }
        
        animator.Play("Pain");
        StartCoroutine(StopAndWait());

    }

    IEnumerator StopAndWait()
    {
        agent.enabled = false;
        yield return new WaitForSeconds(2f);
        agent.enabled = true;
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        agent.enabled = false;
        animator.Play("Attack");
        yield return new WaitForSeconds(animationLength);
        
        //todo: damage
        yield return new WaitForSeconds(cooldown);
        
        isAttacking = false;
        agent.enabled = true;
    }
    
}
