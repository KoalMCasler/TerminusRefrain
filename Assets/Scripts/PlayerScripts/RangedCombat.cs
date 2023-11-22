using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RangedCombat : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public GameObject target;
    public GameObject[] Enemies;
    public Transform projectilePos;
    private int lightTime;
    private int heavyTime;
    public bool WeaponIsHeavy;
    public int attackRange;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player"); 
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("RangedAttack"))
        {
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GetTarget();
            if(target != null && Vector3.Distance(player.transform.position, target.transform.position) < attackRange)
            {
                PassTarget();
                if(WeaponIsHeavy != true)
                {
                    StartCoroutine(LightRangedAttack());
                }
                if(WeaponIsHeavy == true)
                {
                    StartCoroutine(HeavyRangedAttack());
                }
            }
            else
            {
                Debug.Log("No Valid Targets");
            }
        }
        else
        {
            target = null;
        }
    }
    void Shoot()
    {

        Instantiate(projectile, projectilePos.position, Quaternion.identity);
    }
    private IEnumerator LightRangedAttack()
    {
        yield return new WaitForSeconds(lightTime);
        Shoot();
    }
    private IEnumerator HeavyRangedAttack()
    {
        yield return new WaitForSeconds(heavyTime);
        Shoot();
    }
    void GetTarget()
    {
       foreach (var obj in Enemies)
        {
            if (Vector3.Distance(player.transform.position, obj.transform.position) < attackRange)
            {
                target = obj;
                break;
            }
        } 
    }
    void PassTarget()
    {
        if(target != null)
        {
            projectile.GetComponent<Projectile>().target = target;
        }
        else
        {
            Debug.Log("No Valid Targets");
        }
    }
}
