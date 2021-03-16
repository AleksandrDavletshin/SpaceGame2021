using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public UnityEngine.UI.Text scoreLable;
    public UnityEngine.UI.Image menu;
    public UnityEngine.UI.Button startButton;
    public UnityEngine.UI.Button pauseButton;
    public static int score = 0;
    public static bool isStarted = false;//запущена ли игра
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(delegate 
        {
            menu.gameObject.SetActive(false);
            isStarted = true;//запуск игры
        });

        pauseButton.onClick.AddListener(TogglePause);
    }

    public void TogglePause()
    {
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        scoreLable.text = "Score: " + score;
    }
}
