using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AwakeTrigger : MonoBehaviour
{

    public GameObject cutScene;

    [SerializeField]
    private BoxCollider box;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerAttack>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<PlayerMove>().enabled = false;
        cutScene.SetActive(true);

        Debug.Log("Boss Battle Initiated!");
        box.isTrigger = false;
    }
}
