using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum UIState { MainMenu, PauseMenu, LeaderBoard, Settings, InGame, NextLevelScreen, GameOverScreen, GameWinScreen }
    GameManager gameManager;
    Player player;
    UIState state;
    static bool restarted = false;
    static bool movedToNextLevel = false;

    static bool musicON;
    static bool soundON;
    
    [SerializeField] Transform pauseMenu;
    [SerializeField] Transform mainMenu;
    [SerializeField] Transform settingsMenu;
    [SerializeField] Transform leaderBoard;
    [SerializeField] Transform NextLevelScreen;
    [SerializeField] Transform gameOverScreen;
    [SerializeField] Transform gameWinScreen;

    [SerializeField] Sprite onUI;
    [SerializeField] Sprite offUI;

    [SerializeField] Image musicButton;
    [SerializeField] Image soundButton;

    [SerializeField] int finalLevel = 2;

    void Start()
    {
        Time.timeScale = 0;
        // automatically look for game manager in the scene
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        state = UIState.MainMenu;
        if(restarted || movedToNextLevel)
        {
            state = UIState.InGame;
            DisableMenus();
            restarted = false;
            movedToNextLevel = false;
        }
    }

    void Update()
    {
        if (player.CurrentState == Player.PlayerState.Dead)
        {
            state = UIState.GameOverScreen;
        }
        if(player.CurrentState == Player.PlayerState.Survived)
        {
            state = UIState.NextLevelScreen;
        }
        
        
        UpdateGameState();
        UpdateMenusState();
    }

    private void UpdateMenusState()
    {
        DisableMenus();
        if(state != UIState.InGame) {
            transform.GetChild(0).gameObject.SetActive(true);
            switch (state)
            {
                case UIState.MainMenu:
                    mainMenu.gameObject.SetActive(true);
                    break;
                case UIState.PauseMenu:
                    pauseMenu.gameObject.SetActive(true);
                    break;
                case UIState.Settings:
                    settingsMenu.gameObject.SetActive(true);
                    break;
                case UIState.LeaderBoard:
                    leaderBoard.gameObject.SetActive(true);
                    break;
                case UIState.NextLevelScreen:
                    NextLevelScreen.gameObject.SetActive(true);
                    print(state);
                    break;
                case UIState.GameOverScreen:
                    gameOverScreen.gameObject.SetActive(true);
                    break;
                case UIState.GameWinScreen:
                    gameWinScreen.gameObject.SetActive(true);
                    break;
            }
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
    private void DisableMenus()
    {
        foreach (Transform component in transform)
            component.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        DisableMenus();
        if (state == UIState.MainMenu) {
            movedToNextLevel = true;
            SceneManager.LoadScene(0);
            var tut = FindObjectOfType<Tutorial>();
            player.PlayStart();
            tut.Play();
        }
        state = UIState.InGame;
    }

    public void ResumeGame()
    {
        state = UIState.InGame;
        DisableMenus();
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        restarted = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenSettings()
    {
        state = UIState.Settings;
    }

    public void OpenLeaderBoard()
    {
        state = UIState.LeaderBoard;
    }

    public void NextLevel()
    {
        movedToNextLevel = true;
        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current + 1);
    }

    public void ToggleMusic()
    {
        // basically if musicON == true, set musicON = false and vice versa, but in a fancy way
        musicON = !musicON;
        if (musicON)
        {
            musicButton.sprite = onUI;
        }
        else
            musicButton.sprite = offUI;
    }

    public void ToggleSound()
    {
        soundON = !soundON;
        if (soundON)
        {
            soundButton.sprite = onUI;
        }
        else
            soundButton.sprite = offUI;
    }
}
