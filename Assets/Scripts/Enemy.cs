using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxHP = 10;
    private int CurrentHP; 
    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = MaxHP;
    }

    public void TakeDamage(int Damage)
    {
        CurrentHP -= Damage;

        //Play OnHit animation

        if (CurrentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("You Warded off your Shadow!");
        // Death Animation

        // Disable Enemy
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}

