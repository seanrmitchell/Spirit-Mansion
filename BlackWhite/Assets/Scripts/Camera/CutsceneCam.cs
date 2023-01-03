using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCam : MonoBehaviour
{
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

            if(cam.fieldOfView != Camera.main.fieldOfView)
                cam.fieldOfView++;

            if (cam.transform.position == Camera.main.transform.position)
                cam.gameObject.SetActive(false);
        }
    }

    IEnumerator Cutscene(float waittime)
    {
        yield return new WaitForSecondsRealtime(waittime);
            follow = true;
    }


}
