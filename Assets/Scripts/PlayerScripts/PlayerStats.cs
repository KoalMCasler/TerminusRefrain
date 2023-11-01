using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerStats : MainCharacter
{
    public int health;
    public int scrap;
    public int food;
    private string foodString;
    private string scrapString;
    public TextMeshProUGUI FoodHUDObject;
    public TextMeshProUGUI ScrapHUDObject;
    public Collider2D PlayerCollider;
    private string healthString;
    public TextMeshProUGUI healthText;
    public int sceneBuildIndex;
    public GameObject deathText;
    public int knockBack;
    // Start is called before the first frame update
    void Start()
    {
        Initialization();
        deathText.SetActive(false);
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        healthString = string.Format("Health: {0}%", health);
        healthText.text = healthString;
        if(health <= 0)
        {
            mainCharacter.isDead = true;
        }
        if(health >= 100)
        {
            health = 100;
        }
    }
}
