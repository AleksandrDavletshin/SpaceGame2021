using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseSkript : MonoBehaviour
{
    public bool isOpened = false;//открыто ли меню Паузы
    public UnityEngine.UI.Image PauseMenu;
    public UnityEngine.UI.Button QuitButton;
    public UnityEngine.UI.Button ResumeGameButton;
    public static bool GameIsPaused = false;

    public void ShowHideMenu()
    {
        isOpened = !isOpened;
        PauseMenu.gameObject.SetActive(isOpened);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused)
            {
                ShowHideMenu();
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        PauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void GoToMain()
    {
        Controller.isStarted = false;
        GetComponent<Canvas>().enabled = Controller.isStarted;
    }

    public void QuitGame()
    {
        
        Application.Quit(); //Закрытие игры
        Debug.Log("Quitting game...");
    }
}
