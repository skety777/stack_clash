using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public enum GameState { Dashboard, Game, LevelFailed, LevelCompleted }
    public GameState gameState;
    public static Action<GameState> onGameStateChanged;
    public static GameManager instance{ get; private set; }
    private int score;

    public int collectionDiamonds = 0;
    public int levelCompletion = 0;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // revive = GameObject.FindObjectOfType<Revive>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);

        Debug.Log("Current Game State ==> " + gameState);

        switch (gameState)
        {
            case GameState.Dashboard:
            SceneManager.LoadScene("GamePlay");
                break;

            case GameState.Game:
                
                break;

            case GameState.LevelFailed:
            SceneManager.LoadScene("GameOver");
                break;

            case GameState.LevelCompleted:
            SceneManager.LoadScene("GameOver");
                break;

            default:
                break;
        }
    }
    public void increaseScore()
    {
        score = score + 10;
        // scoreText.text = score.ToString();
    }
    public void restartGame()
    {

    }
    public void GameOver()
    {
        Debug.Log("Game OVerrrrrrr Revive");
        // revive.reviveEnable();
    }
}
