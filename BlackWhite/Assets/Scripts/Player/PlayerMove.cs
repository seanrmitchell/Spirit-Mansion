using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Controller playerControls;

    public CharacterController player;

    private Camera cam;

    [SerializeField] //visible in editor
    private float speed, smoothTime;

    [SerializeField]
    private Animator an;

    private float currentVelocity;

    Vector2 movement, rotation;
    Vector3 direction, axis;

    private void OnEnable()
    {
        playerControls.Movement.Enable();
    }

    private void OnDisable()
    {
        playerControls.Movement.Disable();
    }

    private void Awake()
    {
        playerControls = new Controller();


        // Enables player movement controls in script
        playerControls.Movement.WASD.performed += ctx => movement = ctx.ReadValue<Vector2>();
        playerControls.Movement.WASD.canceled += ctx => movement = Vector2.zero;

        // Enables player rotation in script
        playerControls.Movement.Rotation.performed += ctx => rotation = ctx.ReadValue<Vector2>();
        playerControls.Movement.Rotation.canceled += ctx => rotation = Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        // Player Looks at Mouse

        //mousePos = Mouse.current.position.ReadValue();
        //Ray ray = cam.ScreenPointToRay(rotation);
        /*
         * Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(ground.Raycast(ray, out rayLength))
        {
            Vector3 pointToLook = ray.GetPoint(rayLength);
            Debug.DrawLine(ray.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        */

        //transform.LookAt(new Vector3(rotation.x, transform.position.y, rotation.z));

        // saves horizontal movement
        direction = new Vector3(movement.x, -0.75f, movement.y).normalized;
        player.Move(direction * speed * Time.deltaTime);

        an.SetFloat("speed", Mathf.Abs(movement.magnitude));

        // Makes dude move
        //rb.MovePosition(rb.position + direction * speed * Time.deltaTime);


        // Roatation of player

        //axis = new Vector3(-rotation.x, transform.rotation.y, -rotation.y);




        if (rotation != Vector2.zero)
        {
            var targetAngle = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
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
