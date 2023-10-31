using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        // Gets animator component. 
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Triggers animation to play when player is near.
        if(other.tag == "Player") 
        {
            anim.SetBool("PlayerIsNear", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Makes sure to only play when player is near and not loop after they leave the area.
        if(other.tag == "Player") 
        {
            anim.SetBool("PlayerIsNear", false);
        }
    }
}
