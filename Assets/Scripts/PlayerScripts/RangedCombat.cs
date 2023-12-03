using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class RangedCombat : MonoBehaviour
{
    public TextMeshProUGUI AmmoText;
    public GameObject player;
    public GameObject projectile;
    public GameObject target;
    public GameObject[] Enemies;
    public Transform projectilePos;
    public int lightDamage;
    public int heavyDamage;
    static public bool WeaponIsHeavy;
    public int attackRange;
    static public int lightAmmo;
    static public int heavyAmmo;
    public int lightAmmoMax;
    public int heavyAmmoMax;
    private float lightShotCoolDown;
    private float heavyShotCoolDown;
    private int lightShotCoolDownMax;
    private int heavyShotCoolDownMax;
    private bool CanShoot;
    private int shotSpeed;
    private int lightSpeed = 3;
    private int heavySpeed = 7;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        ResetCoolDown();
    }
    // Update is called once per frame
    void Update()
    {
        ShotCoolDown();
        SetHudText();
        if(Input.GetButtonDown("RangedAttack"))
        {
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GetTarget();
            if(target != null && Vector3.Distance(player.transform.position, target.transform.position) < attackRange && CanShoot == true)
            {
                PassTarget();
                PassDamage();
                PassShotSpeed();
                if(WeaponIsHeavy != true)
                {
                    LightRangedAttack();
                }
                if(WeaponIsHeavy == true)
                {
                    HeavyRangedAttack();
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
    void LightRangedAttack()
    {
        if(lightAmmo > 0)
        {
            lightAmmo -= 1;
            Shoot();
            ResetCoolDown();
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
        ResetCoolDown();
    }
    void HeavyRangedAttack()
    {
        if(heavyAmmo > 0)
        {
            heavyAmmo -= 1;
            Shoot();
            ResetCoolDown();
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
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
    void SetHudText()
    {
        if(WeaponIsHeavy == true)
        {
            AmmoText.text = string.Format("Ammo: {0}/{1}", heavyAmmo, heavyAmmoMax);
        }
        else
        {
            AmmoText.text = string.Format("Ammo: {0}/{1}", lightAmmo, lightAmmoMax);
        }        
    }
    void PassDamage()
    {
        if(WeaponIsHeavy == true)
        {
            projectile.GetComponent<Projectile>().damage = heavyDamage;
        }
        if(WeaponIsHeavy == false)
        {
            projectile.GetComponent<Projectile>().damage = lightDamage;
        }
    }
    void ShotCoolDown()
    {
        if(WeaponIsHeavy == true)
        {
            heavyShotCoolDown -= Time.deltaTime;
            if(heavyShotCoolDown <= 0)
            {
                heavyShotCoolDown = 0;
                CanShoot = true;
            }
            else
            {CanShoot = false;}
        }
        if(WeaponIsHeavy == false)
        {
            lightShotCoolDown -= Time.deltaTime;
            if(lightShotCoolDown <= 0)
            {
                lightShotCoolDown = 0;
                CanShoot = true;
            }
            else
            {CanShoot = false;}
        }
    }
    void ResetCoolDown()
    {
        if(WeaponIsHeavy == true)
        {
            heavyShotCoolDown = heavyShotCoolDownMax;
        }
        if(WeaponIsHeavy == false)
        {
           lightShotCoolDown = lightShotCoolDownMax;
        }
    }
    public void SetWeaponHeavy()
    {
        WeaponIsHeavy = true;
        Reload();
    }
    public void SetWeaponLight()
    {
        WeaponIsHeavy = false;
        Reload();
    }
    void PassShotSpeed()
    {
        if(WeaponIsHeavy == true)
        {
            shotSpeed = heavySpeed;
            projectile.GetComponent<Projectile>().shotSpeed = shotSpeed;
        }
        if(WeaponIsHeavy == false)
        {
            shotSpeed = lightSpeed;
            projectile.GetComponent<Projectile>().shotSpeed = shotSpeed;
        }
    }
    public void Reload()
    {
        if(WeaponIsHeavy == true)
        {
            heavyAmmo = heavyAmmoMax;
        }
        if(WeaponIsHeavy != true)
        {
            lightAmmo = lightAmmoMax;
        }
    }
        public void PassHeavyStatus()
    {
        gameObject.GetComponent<EquipmentMenu>().RangedIsHeavy = WeaponIsHeavy;
    }
}
