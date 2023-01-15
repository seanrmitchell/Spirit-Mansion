using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrigger : MonoBehaviour
{
    [SerializeField] GameObject doorClosed;


    public List<GameObject> generators;

    private int number = 0;
    private bool closed = true;

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
            doorClosed.SetActive(false);
            closed = false;
        }
    }
}
