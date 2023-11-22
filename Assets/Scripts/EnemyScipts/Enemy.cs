using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator enemyAnimator;
    // Enemy base HP stat.
    public int MaxHP = 10;
    // Current HP
    private int CurrentHP; 
    // Start is called before the first frame update
    // Sets Current Hp to Max HP on load. 
    void Start()
    {
        enemyAnimator.SetBool("IsHit", false);
        CurrentHP = MaxHP;
    }

    // Function to calculate damage. 
    public void TakeDamage(int Damage)
    {
        //Play OnHit animation
        StartCoroutine(OnHitAnimation());
        CurrentHP -= Damage;

        if (CurrentHP <= 0)
        {
            Die();
        }
    }

    // Causes death state. 
    void Die()
    {
        // Disable Enemy
        Destroy(gameObject);
    }
    private IEnumerator OnHitAnimation()
    {
        enemyAnimator.SetBool("IsHit", true);
        yield return new WaitForSeconds(0.5f);
        enemyAnimator.SetBool("IsHit", false);
    }
}

