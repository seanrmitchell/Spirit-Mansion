using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class BossDoorFunction : MonoBehaviour
{
    [SerializeField] GameObject doorClosed;
    [SerializeField] GameObject doorOpen;

    public List<GameObject> enemies;

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
            BossCheck();
    }

    public void BossCheck()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<BossHealth>().CalculateHealth() <= 0 && !enemy.GetComponent<BossHealth>().destroyed)
            {
                enemy.GetComponent<BossHealth>().destroyed = true;
                number++;
            }
        }

        if (enemies.Count == number)
        {
            doorOpen.SetActive(true);
            doorClosed.SetActive(false);
            closed = false;
        }
    }
}
