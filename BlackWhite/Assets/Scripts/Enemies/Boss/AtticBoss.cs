using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AtticBoss : MonoBehaviour
{
    public NavMeshAgent enemy;

    [SerializeField]
    private float damage, attackCoolDown, attackRange;

    private float attackSpeed;

    private bool playerInSight = false;

    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    private Transform attackPoint;

    private Transform target;



    void Awake()
    {
        target = GameObject.Find("Player").transform;
        enemy.isStopped = true;
    }

    private void Start()
    {
        attackSpeed = 0f;
    }


    void FixedUpdate()
    {
        //if (inside.)

        float distance = Vector3.Distance(target.position, transform.position);

        enemy.SetDestination(target.position);

        if (distance <= enemy.stoppingDistance)
        {
            FacePlayer();
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void FacePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(target.position.x, 0f, target.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
    }
}
