using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    //public float speed;
    //public float distance;

    //private bool movingRight = true;

    //public Transform groundDetection;

    //private void Update()
    //{
    //    transform.Translate(Vector2.right * speed * Time.deltaTime);

    //    RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2.0f, LayerMask.GetMask("Ground"));
    //    if (groundInfo.collider == false)
    //    {
    //        if (movingRight == true)
    //        {
    //            transform.eulerAngles = new Vector3(0, -180, 0);
    //            movingRight = false;
    //        }
    //        else
    //        {
    //            transform.eulerAngles = new Vector3(0, 0, 0);
    //            movingRight = true;
    //        }
    //    }
    //}
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);
    }
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
            Flip();
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
            Flip();
        }
    }

    void Flip()
    {
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    //visualise the points
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        //line path visual
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);

    }
}
