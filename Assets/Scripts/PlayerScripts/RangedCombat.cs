using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RangedCombat : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePos;
    private int lightTime;
    private int heavyTime;
    public bool WeaponIsHeavy;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("RangedAttack"))
        {
            if(WeaponIsHeavy != true)
            {
                StartCoroutine(LightRangedAttack());
            }
            if(WeaponIsHeavy == true)
            {
                StartCoroutine(HeavyRangedAttack());
            }
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
}
