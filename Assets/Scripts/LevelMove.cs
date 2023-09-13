using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class LevelMove : MonoBehaviour
{
    // allows you to set Variable the actual scene build index of choice per level move.
    public int sceneBuildIndex;

    // Attachment for transition effect
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // triggers level move only if player enters area. 
        if(other.tag == "Player") 
        {
            animator.SetBool("Leave", true);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            animator.SetBool("Leave", false);
        }
    }
}