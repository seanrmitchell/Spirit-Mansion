using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltFunction : MonoBehaviour
{

    public float damage;

    private void OnTriggerEnter(Collider other)
    {
           Destroy(gameObject);
    }

}
