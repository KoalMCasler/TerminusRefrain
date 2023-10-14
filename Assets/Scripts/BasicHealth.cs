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
    public GameObject Player;
    protected Collider2D PlayerCollider;
    private Rigidbody2D PlayerRB;
    public int sceneBuildIndex;
    public GameObject DeathText;
    // Start is called before the first frame update
    void Start()
    {
        DeathText.SetActive(false);
        Health = 100;
        PlayerCollider = Player.GetComponent<Collider2D>();
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
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Health -= 20;
            
        }
    }
    void Death()
    {
        Health = 0;
        PlayerRB.bodyType = RigidbodyType2D.Static;
        DeathText.SetActive(true);
        Invoke("Reload", 6); 
    }
    void Reload()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
