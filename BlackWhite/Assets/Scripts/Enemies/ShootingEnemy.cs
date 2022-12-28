using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject boltPreFab;
    public Transform firePos;
        
    [SerializeField]
    private float damage, lookRadius, boltForce;

    private float attackSpeed;

    [SerializeField]
    private float attackCoolDown;

    [SerializeField]
    private Rigidbody player;
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

        transform.position = transform.position;

        if (distance <= lookRadius)
        {
            transform.LookAt(target.position);

            if (attackSpeed >= attackCoolDown)
            {
                GameObject bolt = Instantiate(boltPreFab, firePos.position, firePos.rotation);
                Rigidbody rb = bolt.GetComponent<Rigidbody>();
                rb.AddForce(firePos.forward * boltForce, ForceMode.Impulse);
                attackSpeed = 0f;
            }
            else if (attackSpeed < attackCoolDown)
            {
                attackSpeed += Time.deltaTime;
            }

        }

        




    }

    

}
