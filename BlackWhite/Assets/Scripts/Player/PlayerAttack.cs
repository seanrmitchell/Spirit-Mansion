using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Controller playerControls;

    public Transform firePos, blastPos;

    public GameObject boltPreFab, blastPreFab;

    public float playerDamage;

    [SerializeField]
    private Rigidbody player;

    [SerializeField]
    private LayerMask enemyLayer;

    [SerializeField]
    private float boltForce, blastSize, blastCoolDown, blastDamage;

    private bool isBlasted = false;

    void Awake()
    {
        playerControls = new Controller();
    }

    private void OnEnable()
    {
        playerControls.Attack.Enable();
    }

    private void OnDisable()
    {
        playerControls.Attack.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerControls.Attack.Primary.performed += _ => Primary();
        playerControls.Attack.Secondary.performed += _ => Secondary();
    }

    void FixedUpdate()
    {
        
    }

    private void Primary()
    {
        Debug.Log("Primary!");
        GameObject bolt = Instantiate(boltPreFab, firePos.position, firePos.rotation);
        Rigidbody rb = bolt.GetComponent<Rigidbody>();
        rb.AddForce(firePos.forward * boltForce, ForceMode.Impulse);
    }

    private void Secondary()
    {
        Debug.Log("Secondary!");

        // Determines if enemy is hit by secondary
        if (!isBlasted)
        {
            Collider[] hitEnemy = Physics.OverlapSphere(transform.position, blastSize, enemyLayer);

            foreach (Collider enemy in hitEnemy)
            {
                Debug.Log("Enemy Hit!");
                // Deals damage to enemies in sphere
                enemy.GetComponent<EnemyHealth>().UpdateHealth(blastDamage);
            }
        }

         isBlasted = true;
         StartCoroutine(Blast());
    }

    IEnumerator Blast()
    {
        yield return new WaitForSeconds(blastCoolDown);
            Debug.Log("Cooldown Finished!");
            isBlasted = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, blastSize);
    }

}
