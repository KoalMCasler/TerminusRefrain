using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    private GameObject selfObject;
    private Rigidbody2D self;
    private GameObject player;
    public float shotSpeed;
    public float shotLifeSpan;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        selfObject = GetComponent<GameObject>();
        player = GameObject.FindWithTag("Player");
        self = GetComponent<Rigidbody2D>();
        if(target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            self.velocity = new Vector2(direction.x, direction.y).normalized * shotSpeed;
            target = null;
        }
        else
        {
            Debug.Log("No Valid Targets");
        }
    }

    // Update is called once per frame
    void Update()
    {
        shotLifeSpan -= Time.deltaTime;
        if(shotLifeSpan <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
