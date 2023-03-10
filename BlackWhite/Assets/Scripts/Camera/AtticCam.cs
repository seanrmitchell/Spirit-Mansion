using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtticCam : MonoBehaviour
{

    public GameObject player;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private Transform start, target;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float waittime, speed, rotationSpeed;

    private bool follow = false;

    private void Awake()
    {
        cam.gameObject.SetActive(true);
        player = GameObject.Find("Player");
        player.GetComponent<PlayerMove>().enabled = false;
        player.GetComponentInChildren<Canvas>().enabled = false;
    }

    private void Start()
    {
        cam.transform.position = start.position;
        StartCoroutine(Cutscene(waittime));
    }

    private void FixedUpdate()
    {
        if (follow)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
            transform.rotation = Quaternion.Lerp(cam.transform.rotation, target.rotation, rotationSpeed);

            if (cam.fieldOfView != Camera.main.fieldOfView)
                cam.fieldOfView++;

            if (cam.transform.position == Camera.main.transform.position)
            {
                cam.gameObject.SetActive(false);
                player.GetComponentInChildren<Canvas>().enabled = true;
                player.GetComponent<PlayerMove>().enabled = true;
            }
        }


    }

    IEnumerator Cutscene(float waittime)
    {
        yield return new WaitForSecondsRealtime(waittime);
        follow = true;

        yield return new WaitForSeconds(waittime);
        follow = true;
    }


}