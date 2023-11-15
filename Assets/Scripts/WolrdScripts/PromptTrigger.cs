using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptTrigger : MonoBehaviour
{
    public GameObject promptText;
    // Start is called before the first frame update
    void Start()
    {
        promptText.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            promptText.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
         if(other.CompareTag("Player"))
        {
            promptText.SetActive(false);
        }   
    }
}
