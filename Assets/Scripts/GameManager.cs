using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { PAUSED, PLAY, OVER, WIN }

    public GameState gameState;
    void Start()
    {
        gameState = GameState.PAUSED;
    }

    void Update()
    {
        CheckState();
    }

    private void CheckState()
    {
        switch (gameState)
        {

            case GameState.OVER:
            case GameState.WIN:
            case GameState.PAUSED:
                Time.timeScale = 0;
                break;
            case GameState.PLAY:
                Time.timeScale = 1;
                break;
        }
    }
}
