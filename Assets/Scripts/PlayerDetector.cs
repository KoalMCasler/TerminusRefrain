using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public Collider2D Collider;
    public GameObject Prompt;
    // Start is called before the first frame update
    void Start()
    {
        Prompt.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Player")
        {
            Prompt.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D Other)
    {
        if(Other.tag == "Player")
        {
            Prompt.SetActive(false);
        }
    }
}
