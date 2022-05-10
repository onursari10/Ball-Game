using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public Text scoreText;
    int score;

    public Text taptoStart;
    public GameObject panelGO;
    public GameObject panelTE;
    bool isUserCompleteLevel = false;

    void Start()
    {
        score = 0;

        Time.timeScale = 0;
    }

    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Time.timeScale = 1;
            taptoStart.gameObject.SetActive(false);
            TinySauce.OnGameStarted(SceneManager.GetActiveScene().name);
        }
    }

    public void plusScore(int puan)
    {
        score += puan;
        scoreText.text = " " + score;
    }

    public void gameOver()
    {
        panelGO.SetActive(true);
        Time.timeScale = 0;
    }

    public void theEnd()
    {
        panelTE.SetActive(true);
        Time.timeScale = 0;
        TinySauce.OnGameFinished(isUserCompleteLevel, score, SceneManager.GetActiveScene().name);
    }

}
