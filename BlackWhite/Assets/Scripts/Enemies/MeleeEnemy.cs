using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour
{
    public NavMeshAgent enemy;

    [SerializeField]
    private float damage, lookRadius;

    private float attackSpeed;

    [SerializeField]
    private float attackCoolDown, attackRange;

    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    private Transform attackPoint;

    private Transform target;


    void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        attackSpeed = 0f;
    }


    void FixedUpdate()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            enemy.isStopped = false;
            enemy.SetDestination(target.position);

            if(distance <= enemy.stoppingDistance)
            {
                FacePlayer();
            }
            
        } else
        {
            enemy.isStopped = true;
        }

        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

        foreach (Collider player in hitPlayer)
        {
            if (attackSpeed >= attackCoolDown)
            {
                Debug.Log("Player Hit!");
                player.gameObject.GetComponent<PlayerCondition>().UpdateHealth(damage);
                attackSpeed = 0f;
            }

        }

        if (attackSpeed < attackCoolDown)
        {
            attackSpeed += Time.deltaTime;
        }

    }

    void OnGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FacePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(target.position.x, 0f, target.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
    }
}
