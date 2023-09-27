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

    private void OnTriggerEnter2D(Collider2D Player) 
    {
            sceneInfo.IsNextScene = IsNextScene;
            animator.SetBool("Leave", true);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            animator.SetBool("Leave", false);
    }
}