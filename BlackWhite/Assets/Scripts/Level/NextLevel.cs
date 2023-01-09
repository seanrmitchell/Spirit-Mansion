using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    private int index;

    [SerializeField]
    private GameObject boss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !boss.activeSelf)
        {
            Scene next = SceneManager.GetSceneByBuildIndex(index);
            SceneManager.LoadSceneAsync(index);
            SceneManager.SetActiveScene(next);
        }
    }
}
