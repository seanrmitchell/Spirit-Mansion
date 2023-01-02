using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltFunction : MonoBehaviour
{

    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<PlayerCondition>().UpdateHealth(damage);
        else if (other.gameObject.tag == "Enemy")
            other.gameObject.GetComponent<EnemyHealth>().UpdateHealth(damage);

        Destroy(gameObject);
    }

}
