using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    public UIManager uIManager;
    public LevelManager levelManager;
    public InventoryManager inventoryManager;
    [Header("Object Referances")]
    public GameObject player;
    public enum GameState{ MainMenu, Gameplay, Paused, Options, GameOver, GameWin, Credits}
    [Header("Game State")]
    public GameState gameState;

    public void Start()
    {
        gameState = GameState.MainMenu;

        levelManager = FindObjectOfType<LevelManager>();

        uIManager = FindObjectOfType<UIManager>();
        
        inventoryManager = FindObjectOfType<InventoryManager>();

        player = GameObject.FindWithTag("Player");
        
        ChangeGameState();
    }

    public void ChangeGameState()
    {
        switch(gameState)
        {
            case GameState.MainMenu: MainMenu(); break;
            case GameState.Gameplay: Gameplay(); break;
            case GameState.Paused: Paused(); break;
            case GameState.Options: Options(); break;
            case GameState.GameOver: GameOver(); break;
            case GameState.Credits: Credits(); break;
        }
    }

    void MainMenu()
    {
        if(player.activeSelf)
        {
            player.SetActive(false);
        }
        uIManager.MainMenu();
    }

    void Gameplay()
    {
        uIManager.Gameplay();
    }

    void Paused()
    {
        uIManager.Pause();
    }

    void Options()
    {
        uIManager.Options();
    }

    void GameOver()
    {

    }

    void Credits()
    {
        
    }
}

