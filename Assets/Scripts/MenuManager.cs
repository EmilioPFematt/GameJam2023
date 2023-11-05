using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _MainMenu, _PauseMenu, _HUD, _GameOver, _EndScreen;
    public static bool isPaused { get; private set; } = false;

    void Awake(){
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDestroy() {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void GameManagerOnGameStateChanged(GameState state){
        _MainMenu.SetActive(state == GameState.MainMenu);   
        _HUD.SetActive(state == GameState.Game);
        _GameOver.SetActive(state == GameState.Death);
        _EndScreen.SetActive(state == GameState.End);
    }

    public void StartGame(){
        SoundManager.Instance.playSound(7);
        GameManager.Instance.UpdateGameState(GameState.Game);
    }

    public void SettingsMenu(){
        GameManager.Instance.UpdateGameState(GameState.SettingsMenu);
    }

    public void Quit(){
        Application.Quit();
    }

    public void PauseGame(){
        isPaused = true;
        _PauseMenu.SetActive(true);
         Time.timeScale = 0f;
    }

    public void Resume(){
        isPaused = false;
        _PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    
}
