using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LevelMove : MonoBehaviour
{
    // allows you to set Variable the actual scene build index of choice per level move.
    public string targetScene;
    public bool IsNextScene;
    // Attachment for transition effect
    [SerializeField]
    public SceneInfo sceneInfo;
    public LevelManager levelManager;
    void start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Debug.Log("You Moved Levels");
            sceneInfo.IsNextScene = IsNextScene;
            levelManager.LoadThisScene(targetScene);
        }    
    }
}