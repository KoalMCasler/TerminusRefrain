using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") 
        {
            anim.SetBool("PlayerIsNear", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player") 
        {
            anim.SetBool("PlayerIsNear", false);
        }
    }
}
