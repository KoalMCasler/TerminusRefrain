using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class LevelMove : MonoBehaviour
{
    public int sceneBuildIndex;

    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player") 
        {
            animator.SetBool("Leave", true);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            animator.SetBool("Leave", false);
        }
    }
}