using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float hurtStopTime = 0.3f;
    public int damage = 10;
    public float attackInterval = 0.5f;
    public float attackAnimationLength = 1.5f;
    
    private NavMeshAgent agent;
    private Animator animator;
    private float distance;
    private bool isAttacking;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(target != null && agent.enabled) agent.SetDestination(target.position);
        
        distance = Vector3.Distance(transform.position, target.position);
        
        animator.SetBool("isStopped", distance - agent.stoppingDistance < 0.3f);

        if (distance - agent.stoppingDistance < 0.3f && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        if(isAttacking) yield return null;
        
        isAttacking = true;
        animator.Play("Attack");
        yield return new WaitForSeconds(attackAnimationLength);
        target.GetComponent<Health>().TakeDamage(damage);
        yield return new WaitForSeconds(attackInterval);
        isAttacking = false;
    }

    public void Die()
    {
        agent.enabled = false;
        animator.Play("Die");
        Destroy(this);
    }

    public void GetHurt()
    {
        animator.Play("Pain");
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        agent.enabled = false;
        yield return new WaitForSeconds(hurtStopTime);
        agent.enabled = true;
    }
}
