using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltFunction : MonoBehaviour
{

    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            other.gameObject.GetComponent<EnemyHealth>().UpdateHealth(damage);
        else if (other.gameObject.tag == "Boss")
            other.gameObject.GetComponent<BossHealth>().UpdateHealth(damage);

        Destroy(gameObject);
    }

}
