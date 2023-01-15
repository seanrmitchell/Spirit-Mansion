using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrincessBoss : MonoBehaviour
{
    public NavMeshAgent enemy;

    public GameObject boltPreFab;

    public Transform firePos;

    public GameObject knight;

    public GameObject cutScene;

    [SerializeField]
    private float meleeDamage, meleeCoolDown, meleeRange, rangedCoolDown, rangedDamage, lookRadius, boltForce;

    [SerializeField]
    private int fire;

    private float meleeSpeed, rangedSpeed;

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
        meleeSpeed = 0f;
        rangedSpeed = rangedCoolDown/3;
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

    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            if (rangedSpeed >= rangedCoolDown)
            {
                for(int i = 0; i <= fire; i++)
                {
                    GameObject bolt = Instantiate(boltPreFab, firePos.position, firePos.rotation);
                    bolt.GetComponent<EnemyBoltFunction>().damage = rangedDamage;
                    Rigidbody rb = bolt.GetComponent<Rigidbody>();
                    rb.AddForce(firePos.forward * (boltForce + i), ForceMode.Impulse);
                    rangedSpeed = 0f;
                }
            }
        }

        if (rangedSpeed < rangedCoolDown)
        {
            rangedSpeed += Time.deltaTime;
        }

        if (gameObject.GetComponent<BossHealth>().CalculateHealth() <= 0 && knight.GetComponent<BossHealth>().CalculateHealth() <= 0)
        {
            target.GetComponent<PlayerAttack>().enabled = false;
            target.GetComponent<CharacterController>().enabled = false;
            target.GetComponent<PlayerMove>().enabled = false;
            cutScene.SetActive(true);

            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<PrincessBoss>().enabled = false;
        }
        else if (gameObject.GetComponent<BossHealth>().CalculateHealth() <= 0)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<PrincessBoss>().enabled = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, meleeRange);
    }

    void FacePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(target.position.x, 0f, target.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
    }
}
