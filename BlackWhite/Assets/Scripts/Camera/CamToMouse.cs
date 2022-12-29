using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamToMouse : MonoBehaviour
{
    private Vector3 mousePos;

    [SerializeField] Transform objToMouse;

    [SerializeField] Camera cam;

    private void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        Vector3 point = cam.ScreenToWorldPoint(mousePos);
        objToMouse.position = point;
    }

}
