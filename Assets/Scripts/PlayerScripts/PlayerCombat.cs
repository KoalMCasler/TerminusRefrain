using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform AttackPoint;
    public LayerMask EnemyLayers;

    public float AttackRange = 0.05f;
    public int LightDamage = 1;
    public float WaitTime = 0.5f;
    public int HeavyDamage = 2;
    public bool WeaponIsHeavy;
  
    // Input check
    private void Update()
    {
        // Input
        if (Input.GetButtonDown("MeleeAttack"))
        {
            if(WeaponIsHeavy != true)
            {
                StartCoroutine(LightMeleeAttack());
            }
            if(WeaponIsHeavy == true)
            {
                StartCoroutine(HeavyMeleeAttack());
            }
        }

    }

    // Melee attack logic
    private IEnumerator LightMeleeAttack()
    {
        //Starts Attack Animation
        animator.SetBool("AttackLight", true);
        // Detect enemies in range
        Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);
        // apply damage
        foreach(Collider2D HitEnemy in HitEnemies)
        {
            Debug.Log("You hit " + HitEnemy.name + " for " + LightDamage + " damage");
            HitEnemy.GetComponent<Enemy>().TakeDamage(LightDamage);
        }
        yield return new WaitForSeconds(WaitTime);
        animator.SetBool("AttackLight", false);
    }

    // Debug tool to see the damage zone when in the editor. 
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            {return;}
        
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
    private IEnumerator HeavyMeleeAttack()
    {

        //Starts Attack Animation
        animator.SetBool("AttackHeavy", true);
        // Detect enemies in range
        Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);
        // apply damage
        foreach(Collider2D HitEnemy in HitEnemies)
        {
            Debug.Log("You hit " + HitEnemy.name + " for " + HeavyDamage + " damage");
            HitEnemy.GetComponent<Enemy>().TakeDamage(HeavyDamage);
        }
        yield return new WaitForSeconds(WaitTime);
        animator.SetBool("AttackHeavy", false);
    }
}
