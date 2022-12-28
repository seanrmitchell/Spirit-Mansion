using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenuUI;
    public bool isGameOver;

    public Controller playerInput;

    public GameOver()
    {
        isGameOver = false;
    }

    private void Awake()
    {
        playerInput = new Controller();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    //Determines if the player has run out of health
    public void DetermineGameOver()
    {
        Debug.Log("Player Dead...");
        gameOverMenuUI.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0f;
    }

    // Reset just goes back to the beginning of the scene
    public void Reset()
    {
        Debug.Log("Restarting current level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameOver = false;
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }


}
