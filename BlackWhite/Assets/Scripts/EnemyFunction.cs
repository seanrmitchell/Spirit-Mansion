using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFunction : MonoBehaviour
{
    [SerializeField]
    private float damage, speed;

    private float attackSpeed;

    [SerializeField]
    private float attackCoolDown;

    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    private Rigidbody player;

    private Transform target;


    void Awake()
    {
        target = player.transform;
    }

    private void Start()
    {
        attackSpeed = attackCoolDown;
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
            //other.gameObject.GetComponent<PlayerCondition>().UpdateHealth(damage);
            //attackSpeed = 0f;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (attackSpeed < attackCoolDown)
        {
            attackSpeed += Time.deltaTime;
        }


    }

}
