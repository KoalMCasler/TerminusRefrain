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

    void ResetUI()
    {
        MenuObject.SetActive(false);
        OptionsObject.SetActive(false);
        PauseObject.SetActive(false);
        HUDObject.SetActive(false);
    }

    public void MainMenu()
    {
        ResetUI();
        MenuObject.SetActive(true);
    }
    public void Gameplay()
    {
        ResetUI();
        HUDObject.SetActive(true);
    }
    public void Pause()
    {
        ResetUI();
        PauseObject.SetActive(true);
    }
    public void Options()
    {
        ResetUI();
        OptionsObject.SetActive(true);
    }
}
