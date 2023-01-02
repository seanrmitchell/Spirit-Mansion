using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DoorFunction : MonoBehaviour
{

    [SerializeField] GameObject doorClosed;
    [SerializeField] GameObject doorOpen;

    public List<GameObject> generators;

    private int number = 0;
    private bool closed = true;
    // Start is called before the first frame update
    void Start()
    {
        doorOpen.SetActive(false);
        doorClosed.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (closed)
            GeneratorCheck();
    }

    public void GeneratorCheck()
    {
        foreach (GameObject generator in generators)
        {
            if (generator.GetComponent<Generator>().CalculateHealth() <= 0 && !generator.GetComponent<Generator>().destroyed)
            {
                generator.GetComponent<Generator>().destroyed = true;
                number++;
            }
        }

        if (generators.Count == number)
        {
            doorOpen.SetActive(true);
            doorClosed.SetActive(false);
            closed = false;
        }
    }
}
