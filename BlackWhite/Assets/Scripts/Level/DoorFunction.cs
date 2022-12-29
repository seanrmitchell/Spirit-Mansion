using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFunction : MonoBehaviour
{

    [SerializeField] GameObject doorClosed;
    [SerializeField] GameObject doorOpen;

    public GameObject generator;
    // Start is called before the first frame update
    void Start()
    {
        doorOpen.SetActive(false);
        doorClosed.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (generator.GetComponent<Generator>().CalculateHealth() <= 0)
        {
            doorOpen.SetActive(true);
            doorClosed.SetActive(false);
        }
    }
}
