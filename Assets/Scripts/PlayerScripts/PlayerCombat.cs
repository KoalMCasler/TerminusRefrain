using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform AttackPoint;
    public LayerMask EnemyLayers;
    public float AttackRange;
    public int LightDamage = 1;
    public float LightWaitTime = 0.05f;
    public float HeavyWaitTime = 0.1f;
    public int HeavyDamage = 2;
    static public bool WeaponIsHeavy;
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
        if(WeaponIsHeavy == true)
        {
            AttackRange = 0.2f;
        }
        else
        {
            AttackRange = 0.1f;
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
        yield return new WaitForSeconds(LightWaitTime);
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
        yield return new WaitForSeconds(HeavyWaitTime);
        animator.SetBool("AttackHeavy", false);
    }
    private void DebugControl()
    {
        if(Input.GetButtonDown("DebugWeaponSwap"))
        {
            if(WeaponIsHeavy == true)
            {
                WeaponIsHeavy = false;
                Debug.Log("You swapped to the light Melee.");
            }
            else
            {
                WeaponIsHeavy = true;
                Debug.Log("You swapped to the heavy Melee.");
            }
        }
    }
    public void SetMeleeHeavy()
    {
        if(WeaponIsHeavy != true)
        {
            WeaponIsHeavy = true;
        }
        else
        {return;}
    }
    public void SetMeleeLight()
    {
        if(WeaponIsHeavy == true)
        {
            WeaponIsHeavy = false;
        }
        else
        {return;}
    }
}

