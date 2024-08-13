using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMoveTrigger : MonoBehaviour
{
    public LevelManager levelManager;
    public string targetScene;
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.gameObject.CompareTag("Player"))
        {
            levelManager.LoadThisScene(targetScene);
        }
    }
}
