using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class LevelMove : MonoBehaviour
{
    // allows you to set Variable the actual scene build index of choice per level move.
    public int sceneBuildIndex;
    public bool IsNextScene;
    // Attachment for transition effect
    public Animator animator;
    [SerializeField]
    public SceneInfo sceneInfo;
    public GameObject player;
    void start()
    {
        if(player == null)
        {player = GameObject.FindWithTag("Player");}
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Debug.Log("You Moved Levels");
            sceneInfo.IsNextScene = IsNextScene;
            animator.SetBool("Leave", true);
            player.SetActive(false);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            player.SetActive(true);
            animator.SetBool("Leave", false);
        }    
    }
}