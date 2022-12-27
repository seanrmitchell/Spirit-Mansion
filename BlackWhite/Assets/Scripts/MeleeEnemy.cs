using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour
{
    public NavMeshAgent enemy;

    public bool PlayerInArea;

    [SerializeField]
    private float damage, lookRadius;

    private float attackSpeed;

    [SerializeField]
    private float attackCoolDown;

    [SerializeField]
    private LayerMask playerLayer;

    private Transform target;


    void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        attackSpeed = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (attackSpeed >= attackCoolDown)
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerCondition>().UpdateHealth(damage);
                attackSpeed = 0f;
            }

        if (other.gameObject.tag == "Player Attack")
        {
            gameObject.GetComponent<EnemyHealth>().UpdateHealth(other.GetComponent<BoltFunction>().damage);
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            enemy.SetDestination(target.position);

            if(distance <= enemy.stoppingDistance)
            {
                FacePlayer();
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
