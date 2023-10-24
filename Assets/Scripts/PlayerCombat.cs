using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform AttackPoint;
    public LayerMask EnemyLayers;

    public float AttackRange = 0.05f;
    public int BaseDamage = 1;
    public float WaitTime = 0.5f;
  
    // Input check
    private void Update()
    {
        // Input
        if (Input.GetButtonDown("MeleeAttack"))
        {
            StartCoroutine(MeleeAttack());
        }

    }

    // Melee attack logic
    private IEnumerator MeleeAttack()
    {
        //Starts Attack Animation
        animator.SetBool("Attacking", true);
        // Detect enemies in range
        Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);
        // apply damage
        foreach(Collider2D HitEnemy in HitEnemies)
        {
            Debug.Log("You hit " + HitEnemy.name);
            HitEnemy.GetComponent<Enemy>().TakeDamage(BaseDamage);
        }
        yield return new WaitForSeconds(WaitTime);
        animator.SetBool("Attacking", false);
    }

    // Debug tool to see the damage zone when in the editor. 
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            {return;}
        
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}

