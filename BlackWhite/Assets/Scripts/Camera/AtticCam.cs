using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtticCam : MonoBehaviour
{

    public GameObject player;
    public GameObject canvas;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private Transform start, target;

    [SerializeField]
    private float waittime, speed, rotationSpeed;

    private bool follow = false;

    private void Awake()
    {
        cam.gameObject.SetActive(true);
        player = GameObject.Find("Player");
        player.GetComponent<PlayerMove>().enabled = false;
        canvas.SetActive(false);
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
                canvas.SetActive(true);
                player.GetComponent<PlayerMove>().enabled = true;
            }
        }


    }

    IEnumerator Cutscene(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        follow = true;
    }
}