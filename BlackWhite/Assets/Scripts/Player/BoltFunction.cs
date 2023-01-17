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
        else if (other.gameObject.layer == 9)
            other.gameObject.GetComponent<BossHealth>().UpdateHealth(damage);
        else if (other.gameObject.tag == "Generator")
            other.gameObject.GetComponent<Generator>().UpdateHealth(damage);


        if (!(other.gameObject.tag == "Bolt"))
            Destroy(gameObject);
    }

}
