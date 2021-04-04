using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public UnityEngine.UI.Text scoreLable;
    public UnityEngine.UI.Image menu;
    public UnityEngine.UI.Button startButton;
    public static int score = 0;
    public static bool isStarted = false;//запущена ли игра
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
            startButton.onClick.AddListener(delegate
            {
                menu.gameObject.SetActive(false);
                isStarted = true;//запуск игры
            });

        if (isStarted == true)
        {
            Time.timeScale = 1;//если игра запущена, снять с паузы и обнулить счетчик очков
            score = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreLable.text = "Score: " + score;
        
    }
}
