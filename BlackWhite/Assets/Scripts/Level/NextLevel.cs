using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject boss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !boss.activeSelf)
        {
            Next();
        }
    }

    public void Next()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        index++;
        SceneManager.LoadScene(index);
    }
}
