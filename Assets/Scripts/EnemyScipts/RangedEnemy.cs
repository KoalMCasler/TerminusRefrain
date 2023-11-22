using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePos;
    public GameObject player;
    public int attackRange;
    private float shotTime;
    // Start is called before the first frame update
    void Start()
    {
        
        shotTime = 2;
        player= GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        shotTime -= Time.deltaTime;
        if(shotTime <= 0)
        {
            if(Vector3.Distance(player.transform.position, gameObject.transform.position) < attackRange)
            {
                Shoot();
            }
            shotTime = 2;
        }
        
    }
     void Shoot()
    {
        Instantiate(projectile, projectilePos.position, Quaternion.identity);
    }
}
