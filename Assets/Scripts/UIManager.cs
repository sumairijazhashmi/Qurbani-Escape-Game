using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum UIState { MainMenu, PauseMenu, LeaderBoard, Settings, InGame }
    GameManager gameManager;
    Player player;
    UIState state;

    [SerializeField] Transform pauseMenu;
    [SerializeField] Transform mainMenu;
    [SerializeField] Transform settingsMenu;
    [SerializeField] Transform leaderBoard;

    void Start()
    {
        // automatically look for game manager in the scene
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        state = UIState.MainMenu;
    }

    void Update()
    {
        if (player.CurrentState == Player.PlayerState.Dead)
        {
            state = UIState.PauseMenu;
        }

        UpdateGameState();
        UpdateMenusState();
    }

    private void UpdateMenusState()
    {
        switch (state)
        {
            case UIState.MainMenu:
                pauseMenu.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                leaderBoard.gameObject.SetActive(false);
                mainMenu.gameObject.SetActive(true);
                break;
            case UIState.PauseMenu:
                pauseMenu.gameObject.SetActive(true);
                settingsMenu.gameObject.SetActive(false);
                leaderBoard.gameObject.SetActive(false);
                mainMenu.gameObject.SetActive(false);
                break;
            case UIState.Settings:
                pauseMenu.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(true);
                leaderBoard.gameObject.SetActive(false);
                mainMenu.gameObject.SetActive(false);
                break;
            case UIState.LeaderBoard:
                pauseMenu.gameObject.SetActive(false);
                settingsMenu.gameObject.SetActive(false);
                leaderBoard.gameObject.SetActive(true);
                mainMenu.gameObject.SetActive(false);
                break;
        }
    }
    private void UpdateGameState()
    {
        switch (state)
        {
            case UIState.MainMenu:
                gameManager.gameState = GameManager.GameState.PAUSED;
                break;
            case UIState.InGame:
                gameManager.gameState = GameManager.GameState.PLAY;
                break;
        }
    }

    public void StartGame()
    {
        DisableMenus();
        state = UIState.InGame;
    }

    private void DisableMenus()
    {
        foreach (Transform component in transform)
            component.gameObject.SetActive(false);
    }
}
