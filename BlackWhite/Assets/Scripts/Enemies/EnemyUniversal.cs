using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUniversal : MonoBehaviour
{
    public NavMeshAgent enemy;

    public GameObject boltPreFab;
    public Transform firePos;

    [SerializeField]
    private float meleeDamage, meleeCoolDown, meleeRange, rangedCoolDown, rangedDamage, lookRadius, boltForce;

    private float meleeSpeed, rangedSpeed;

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
        meleeSpeed = 0f;
        rangedSpeed = 0f;
    }


    void FixedUpdate()
    {
        
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            enemy.isStopped = false;
            enemy.SetDestination(target.position);

            if (distance <= enemy.stoppingDistance)
            {
                FacePlayer();
            }

        }
        else
        {
            enemy.isStopped = true;
        }

        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, meleeRange, playerLayer);

        foreach (Collider player in hitPlayer)
        {
            if (meleeSpeed >= meleeCoolDown)
            {
                Debug.Log("Player Hit!");
                player.gameObject.GetComponent<PlayerCondition>().UpdateHealth(meleeDamage);
                meleeSpeed = 0f;
            }

        }

        if (meleeSpeed < meleeCoolDown)
        {
            meleeSpeed += Time.deltaTime;
        }

        if (distance <= lookRadius)
        {
            if (rangedSpeed >= rangedCoolDown)
            {
                GameObject bolt = Instantiate(boltPreFab, firePos.position, firePos.rotation);
                bolt.GetComponent<EnemyBoltFunction>().damage = rangedDamage;
                Rigidbody rb = bolt.GetComponent<Rigidbody>();
                rb.AddForce(firePos.forward * boltForce, ForceMode.Impulse);
                rangedSpeed = 0f;
            }
        }

        if (rangedSpeed < rangedCoolDown)
        {
            rangedSpeed += Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
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