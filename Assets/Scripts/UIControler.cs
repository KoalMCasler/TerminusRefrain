using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControler : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject GameUI;
    public GameObject PauseMenuUI;
    public void EndGame()
    {
        Debug.Log("You pressed quit");
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused == true)
            {
                ResumeGame();
            }
            if(GameIsPaused == false)
            {
                PauseGame();
            }
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        PauseMenuUI.SetActive(false);
        GameUI.SetActive(true);
    }
    void PauseGame()
    {
        GameIsPaused = true;
        GameUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
