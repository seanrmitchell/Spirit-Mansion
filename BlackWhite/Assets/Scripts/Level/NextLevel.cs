using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    private int index;

    private void OnTriggerEnter(Collider other)
    {
        Scene next = SceneManager.GetSceneByBuildIndex(index);
        SceneManager.SetActiveScene(next);
    }
}
