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
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("LedgeClimbing") == true)
        {
            anim.SetBool("LedgeHanging", false);
        }
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
