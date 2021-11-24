using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject PauseScreen;
    public GameObject SettingMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseScreen.SetActive(false);
        SettingMenu.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Pause()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseButton()
    {
        if (IsGamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void OpenSettings()
    {
        SettingMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        SettingMenu.SetActive(false);
    }
}
