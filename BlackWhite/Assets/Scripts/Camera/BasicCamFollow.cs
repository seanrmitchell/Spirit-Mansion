using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCamFollow : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] Vector3 offset;

    void FixedUpdate()
    {
        transform.position = player.position + offset;

        
    }
}
