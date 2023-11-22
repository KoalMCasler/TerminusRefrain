using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject target;
    private GameObject selfObject;
    private Rigidbody2D self;
    public GameObject[] Enemies;
    public int shotRange;
    private GameObject player;
    public float shotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        selfObject = GetComponent<GameObject>();
        player = GameObject.FindWithTag("Player");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        self = GetComponent<Rigidbody2D>();
        GetTarget();
        if(target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            self.velocity = new Vector2(direction.x, direction.y).normalized * shotSpeed;
        }
        else
        {
            Debug.Log("No Valid Targets");
            Destroy(selfObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetTarget()
    {
       foreach (var obj in Enemies)
        {
            if (Vector3.Distance(player.transform.position, obj.transform.position) < shotRange)
            {
                target = obj;
                break;
            }
        } 
    }
}
