using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private GameObject target;
    private Rigidbody2D self;
    public int shotRange;
    public GameObject player;
    public float shotLifeSpan;
    public float shotSpeed;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        self = GetComponent<Rigidbody2D>();
        target = player;
        Vector3 direction = target.transform.position - transform.position;
        self.velocity = new Vector2(direction.x, direction.y).normalized * shotSpeed;
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
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
