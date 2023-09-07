using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AtticBoss : MonoBehaviour
{
    public NavMeshAgent enemy;

    public GameObject cutScene;

    [SerializeField]
    private float damage, attackCoolDown, attackRange;

    private float attackSpeed;

    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    Animator an;

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

    private void Update()
    {
        if (gameObject.GetComponent<BossHealth>().CalculateHealth() <= 0)
        {
            target.GetComponent<PlayerAttack>().enabled = false;
            target.GetComponent<CharacterController>().enabled = false;
            target.GetComponent<PlayerMove>().enabled = false;
            cutScene.SetActive(true);

            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<AtticBoss>().enabled = false;
        }

        an.SetFloat("speed", enemy.velocity.magnitude / enemy.speed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void FacePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(target.position.x, 0f, target.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
    }
}
