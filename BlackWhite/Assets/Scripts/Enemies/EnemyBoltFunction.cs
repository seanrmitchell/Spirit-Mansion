using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoltFunction : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<PlayerCondition>().UpdateHealth(damage);

        Destroy(gameObject);
    }
}
