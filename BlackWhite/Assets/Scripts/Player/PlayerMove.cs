using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public InputAction playerControls;

    public CharacterController player;

    public Camera cam;

    [SerializeField] //visible in editor
    private float speed;

    Vector2 movement, mousePos;
    Vector3 direction;

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
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        // Player Looks at Mouse

        mousePos = Mouse.current.position.ReadValue();
        Ray ray = cam.ScreenPointToRay(mousePos);
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
        direction = new Vector3(movement.x, -0.25f , movement.y).normalized;

        // Makes dude move
        //rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        //Vector3 move = transform.right * direction.x + transform.forward * direction.z;
        player.Move(direction * speed * Time.deltaTime);
        //rb.velocity = direction * speed * Time.deltaTime;

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
