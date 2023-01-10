using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamToMouse : MonoBehaviour
{
    private Vector3 mousePos;

    [SerializeField] Transform objToMouse;

    [SerializeField] Camera cam;

    [SerializeField] Transform player;

    private void Awake()
    {
        objToMouse.position = player.position;
    }

    private void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        Ray ray = cam.ScreenPointToRay(mousePos);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (ground.Raycast(ray, out rayLength))
        {
            Vector3 pointToLook = ray.GetPoint(rayLength);
            Debug.DrawLine(ray.origin, pointToLook, Color.blue);

            Vector3 point = new Vector3(pointToLook.x, transform.position.y, pointToLook.z);

            Vector3 offset = point - player.position;

            objToMouse.position = player.position + Vector3.ClampMagnitude(offset, 5);
        }
    }

}
