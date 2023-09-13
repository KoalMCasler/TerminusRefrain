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
  
    // Input check
    private void Update()
    {
        // Input
        if (Input.GetButtonDown("MeleeAttack"))
        {
            MeleeAttack();
        }

    }

    // Melee attack logic
    private void MeleeAttack()
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
    }

    // Debug tool to see the damage zone when in the editor. 
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            {return;}
        
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}

