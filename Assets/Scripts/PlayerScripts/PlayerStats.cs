using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    public int deathTime;
    public GameObject winText;
    public int enemyDamage;
    // Start is called before the first frame update
    void Start()
    {
        Initialization();
        deathText.SetActive(false);
        health = 100;
        deathTime = 3;
        enemyDamage = 20;
        winText.SetActive(false);
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
        foodString = string.Format("Food: {0}", food);
        scrapString = string.Format("Scrap: {0}", scrap);
        FoodHUDObject.text = foodString;
        ScrapHUDObject.text = scrapString;
        if(mainCharacter.isDead == true)
        {
            Death();
        }
        if (scrap >= 6)
        {
            Win();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        ColCheck(other.gameObject);
    }
    void Death()
    {
        health = 0;
        Invoke("Reload", deathTime);
        mainCharacter.inputEnabled = false;
        deathText.SetActive(true);
    }
    void Reload()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
    void Win()
    {
        Invoke("Reload", deathTime);
        mainCharacter.inputEnabled = false;
        winText.SetActive(true);
    }
    private void ColCheck(GameObject col)
    {
        if(col.CompareTag("Enemy"))
        {
            health -= enemyDamage;
            //col.gameObject.SetActive(false); Debug Function.
            Debug.Log(string.Format("you took {0} damage", enemyDamage));
            Debug.Log(string.Format("you touched {0}", col.name));
        }
        if(col.CompareTag("Scrap"))
        {
            Debug.Log(string.Format("you touched some {0}", col.name));
            scrap += 1;
            col.gameObject.SetActive(false);
        }
    }
    public void TakeDamage(int damage)
    {
        health -=damage;
    }
}
