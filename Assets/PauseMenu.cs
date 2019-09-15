using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;

    public void Start()
    {
        if (pauseMenuUI == null)
        {
#if UNITY_EDITOR
            Debug.LogError("Pause Menu Script has missing PauseMenuUI reference in Canvas!");
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }


    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        // SceneManager.LoadScene...
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
