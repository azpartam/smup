using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMananger : MonoBehaviour
{
    private static GameMananger m_instance;
    public static GameMananger Instance
    {
        get {
            if (m_instance == null)
                m_instance = FindObjectOfType<GameMananger>();
            if (m_instance == null)
            {
                GameObject gameManagerObject = new GameObject("GameManager");
                m_instance = gameManagerObject.AddComponent<GameMananger>();
                
            }

            return m_instance;
        }            
    }

    public enum GameState { Start, InGame, GameOver, GameFinished };

    private GameState m_gameState;
    private int m_score;

    public GameState gameState { get => m_gameState; }
    public int Score { get => m_score; }
    public delegate void ScoreChanged();
    public static event ScoreChanged OnScoreChanged;


    void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            //TODO: change this to Start
            m_gameState = GameState.InGame;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    
    private void Update()
    {
     
        if ((m_gameState == GameState.GameOver || m_gameState == GameState.GameFinished) && Input.GetKeyDown(KeyCode.Return))
        {
            m_gameState = GameState.Start;
            SceneManager.LoadScene("Menu");
        }
    }

    public void IncreaseScore(int _points)
    {
        m_score += _points;
        if (OnScoreChanged is not null)
            OnScoreChanged();
    }

    public void PlayerDied()
    {
        m_gameState = GameState.GameOver;
        Time.timeScale = 0;
        SceneManager.LoadScene("EndOfGame");       
    }

    public void EndOfLevel()
    {
        m_gameState = GameState.GameFinished;
        Time.timeScale = 0;
        SceneManager.LoadScene("EndOfGame");
    }
  
    public void StartGame()
    {
        m_gameState = GameState.InGame;
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        m_score = 0;
    }

    public void QuitGame()
    { 
        Application.Quit();
    }
}
