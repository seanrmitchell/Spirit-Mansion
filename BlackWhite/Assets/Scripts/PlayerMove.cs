using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public InputAction playerControls;

    [SerializeField] //visible in editor
    private float maxSpeed, speed, turnSmoothing;

    float turnVelocity;

    [SerializeField]
    private Transform groundCheck, cam;

    [SerializeField]
    private LayerMask groundObjects;

    [SerializeField]
    private Rigidbody rb;

    Vector2 movement;
    Vector2 mousePos;
    Vector3 worldPos;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        //worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(ground.Raycast(ray, out rayLength))
        {
            Vector3 pointToLook = ray.GetPoint(rayLength);
            Debug.DrawLine(ray.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        // Gets horizontal input
        movement = playerControls.ReadValue<Vector2>();
        Vector3 direction = new Vector3(movement.x, 0f, movement.y).normalized;

        // calculates movement on ground
        if (direction.magnitude >= 0.1f)
        {


            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSmoothing);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            // Makes dude move

            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);

        }
    }

    private void FixedUpdate()
    {
        
    }

    private void Attack(int x)
    {
        switch (x)
        {
            case 1:
                Debug.Log("Primary Attack!");
                break;
            case 2:
                Debug.Log("Special Attack!");
                break;
        }
    }
}
