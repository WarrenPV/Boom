using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject PauseScreen;
    public GameObject SettingMenu;
    public GameObject LoseMenu;
    public static bool Died;
    private AudioSource audiosource;
    public AudioClip buttonPress;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audiosource.PlayOneShot(buttonPress);
            if(IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Died)
        {
            Dead();
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Resume()
    {
        audiosource.PlayOneShot(buttonPress);
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
        Died = false;
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        audiosource.PlayOneShot(buttonPress);
        Application.Quit();
    }
    public void PauseButton()
    {
        audiosource.PlayOneShot(buttonPress);
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
        audiosource.PlayOneShot(buttonPress);
        SettingMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        audiosource.PlayOneShot(buttonPress);
        SettingMenu.SetActive(false);
    }

    public void Dead()
    {
        Time.timeScale = 0f;
        IsGamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        LoseMenu.SetActive(true);
    }

}
