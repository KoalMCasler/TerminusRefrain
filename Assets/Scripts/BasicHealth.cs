using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BasicHealth : MonoBehaviour
{
    public int Health;
    private string HealthString;
    public TextMeshProUGUI HealthText;
    public Collider2D PlayerCollider;
    private GameObject Player;
    private Rigidbody2D PlayerRB;
    public int sceneBuildIndex;
    public GameObject DeathText;
    public Vector2 KnockBack;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Character>().gameObject;
        KnockBack = new Vector2(2,0);
        DeathText.SetActive(false);
        Health = 100;
        PlayerRB = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthString = string.Format("Health: {0}%", Health);
        HealthText.text = HealthString;
        if(Health <= 0)
        {
            Death();
        }
        if(Health >= 100)
        {
            Health = 100;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Health -= 20;
            if(Player.GetComponent<Character>().isFacingLeft == true)
            {
                PlayerRB.velocity = -KnockBack;
            }
            else
            {
                PlayerRB.velocity = KnockBack;
            }
        }
    }
    void Death()
    {
        Health = 0;
        Invoke("Reload", 5); 
        DeathText.SetActive(true);
    }
    void Reload()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
