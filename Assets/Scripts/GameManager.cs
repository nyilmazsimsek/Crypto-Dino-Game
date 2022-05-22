using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gamePlayPanel;
    public GameObject pausePanel;
    public GameObject startMenuPanel;
    public GameObject endGamePanel;

    public TMP_Text scoreText;
    public TMP_Text bestScoreText;
    
    public bool isGameStarted;
    public bool isGamePaused;
    private void Awake()
    {
        Instance = this;
        isGameStarted = isGamePaused = false;
        startMenuPanel.SetActive(true);
        endGamePanel.SetActive(false);
        pausePanel.SetActive(false);
        gamePlayPanel.SetActive(false);
    }
    private void Update()
    {
        if (!Player.Instance.isAlive)
        {
            gamePlayPanel.SetActive(false);
            endGamePanel.SetActive(true);
        }
        scoreText.text = "SCORE: " + Math.Floor(Player.Instance.score);
        bestScoreText.text = " BEST SCORE: " + Math.Floor(Player.Instance.bestScore);
    }

    public void StartButton()
    {
        isGameStarted = true;
        startMenuPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
    }

    public void PauseButton()
    {
        pausePanel.SetActive(true);
        isGamePaused = true;
    }

    public void ContinueButton()
    {
        pausePanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        isGamePaused = false;
    }
    
    public void BackMenuButton()
    {
        endGamePanel.SetActive(false);
        startMenuPanel.SetActive(true);
        pausePanel.SetActive(false);
        isGameStarted = false;
        isGamePaused = false;
    }
}