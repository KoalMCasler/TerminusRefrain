using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D enemyRB;
    private Transform currentPoint;
    public bool isFacingLeft;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        isFacingLeft = false;
        enemyRB = gameObject.GetComponent<Rigidbody2D>();
        currentPoint = pointA.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Flip();
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointA.transform)
        {
            enemyRB.velocity = new Vector2(-speed, 0);
        }
        else
        {
            enemyRB.velocity = new Vector2(speed, 0);
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            Flip();
            currentPoint = pointB.transform;
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            Flip();
            currentPoint = pointA.transform;
        }
    }
    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
