using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    // Start is called before the first frame update
    void Awake()
    {
      Instance = this;   
    }

    void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }

    // Update is called once per frame
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch(newState){
            case GameState.MainMenu:
                HandleMainMenu();
                break;
            case GameState.SettingsMenu:
                HandleSettingsMenu();
                break;
            case GameState.Game:
                HandleGame();
                break;
            case GameState.PauseMenu:
                HandlePauseMenu();
                break;
            case GameState.Desktop:
                HandleDesktop();
                break;
            case GameState.Death:
                HandleDeath();
                break;
            case GameState.End:
                HandleEnd();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleMainMenu(){
        Time.timeScale = 0f;
    }

    private void HandleSettingsMenu(){
        
    }

    private void HandleGame(){
        Time.timeScale = 1f;
        MusicManager.Instance.ChangeToGameMusic();
    }

    private void HandlePauseMenu(){

    }

    private void HandleDesktop(){

    }

    private void HandleDeath(){

    }

    private void HandleEnd(){

    }
}

public enum GameState{
    MainMenu,
    SettingsMenu,
    Game,
    PauseMenu,
    Desktop,
    Death,
    End
}
