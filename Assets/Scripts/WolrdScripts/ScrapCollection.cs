using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScrapCollection : MonoBehaviour
{
    private GameObject scrap;
    public GameObject player;
    public PlayerStats playerStats;
    void start()
    {
        scrap = gameObject;
        player = GameObject.FindWithTag("Player");
        if(player == null)
        {return;}
        else
        {
            playerStats = player.GetComponent<PlayerStats>();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerStats.scrap += 1;
            scrap.SetActive(false);
        }
    }
}
