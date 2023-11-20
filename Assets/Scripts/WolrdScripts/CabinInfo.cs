using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class CabinInfo : MonoBehaviour
{
    public GameObject PromptText;
    private bool HasBeenEntered;
    // Start is called before the first frame update
    void Start()
    {
        DeactivateText();
        HasBeenEntered = false;
    }
    // Update is called once per frame
    void DeactivateText()
    {
        PromptText.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && HasBeenEntered == false)
        {
            PromptText.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            DeactivateText();
            HasBeenEntered = true;
        }
    }
}
