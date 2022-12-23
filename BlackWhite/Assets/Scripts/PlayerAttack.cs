using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Controller playerControls;

    public Transform firePos, blastPos;

    public GameObject boltPreFab, blastPreFab;

    [SerializeField]
    private Rigidbody player;

    [SerializeField]
    private float boltForce, blastSize;

    public float playerDamage;

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
        StartCoroutine(Blast());
    }

    IEnumerator Blast()
    {
        GameObject blast = Instantiate(blastPreFab, blastPos.position, blastPos.rotation);
        yield return new WaitForSeconds(blastSize);
        Destroy(blast);
    }

}
