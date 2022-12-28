using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCamFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;
    void Update()
    {
        transform.position = player.transform.position+offset;
    }
}
