using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathCam : MonoBehaviour
{
    [SerializeField]
    private Transform camLook;

    [SerializeField]
    private Transform boss, player;
    
    // Start is called before the first frame update
    void Start()
    {
        camLook.position = boss.position;
    }

    // Update is called once per frame
    void Update()
    {
        camLook.position = (boss.position + player.position)/2;
    }
}
