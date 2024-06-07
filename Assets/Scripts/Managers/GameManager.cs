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

    public void Awake()
    {
        gameState = GameState.MainMenu;

        levelManager = FindObjectOfType<LevelManager>();

        uIManager = FindObjectOfType<UIManager>();
        
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    void Update()
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

    }

    void Gameplay()
    {

    }

    void Paused()
    {

    }

    void Options()
    {

    }

    void GameOver()
    {

    }

    void Credits()
    {
        
    }
}

