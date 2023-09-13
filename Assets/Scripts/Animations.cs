using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    Animator anim;
    float yVelocity;
    // Start is called before the first frame update
    void Start()
    {
        // Gets the Animator component. 
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Conditionals to control the bools that trigger specific animations.  
        if (anim.GetBool("LedgeClimbing") == true)
        {
            anim.SetBool("LedgeHanging", false);
        }
        // Separates jump from fall animation.
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            yVelocity += 1f;
        }
        else 
        {
            yVelocity = 0;
        }
        anim.SetFloat("yVelocity", yVelocity);
    }
}
