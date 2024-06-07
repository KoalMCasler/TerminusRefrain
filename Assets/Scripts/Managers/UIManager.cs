using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Object Referances")]
    public GameManager gameManager;
    public GameObject player;
    [Header("UI Referances")]
    public GameObject MenuObject;
    public GameObject OptionsObject;
    public GameObject PauseObject;
    public GameObject HUDObject;

    void Start()
    {
        player = gameManager.player;
    }

    void Update()
    {
        
    }

    public void MainMenu()
    {
        
    }
}
