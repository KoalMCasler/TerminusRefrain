using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CabinBed : MonoBehaviour
{
    public GameObject prompt;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            prompt.SetActive(true);
            other.GetComponent<PlayerStats>().CanHeal = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            prompt.SetActive(false);
            other.GetComponent<PlayerStats>().CanHeal = false;
        }
    }
}
