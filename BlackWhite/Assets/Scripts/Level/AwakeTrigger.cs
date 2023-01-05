using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AwakeTrigger : MonoBehaviour
{

    public NavMeshAgent enemy;

    [SerializeField]
    private BoxCollider box;

    [SerializeField]
    private GameObject bar;

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        enemy.isStopped = false;
        bar.SetActive(true);
        Debug.Log("Boss Battle Initiated!");
        box.isTrigger = false;
    }
}
