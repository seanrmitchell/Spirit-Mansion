using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player Attack")
        {
            gameObject.GetComponent<EnemyHealth>().UpdateHealth(other.GetComponent<BoltFunction>().damage);
        }
    }
}
