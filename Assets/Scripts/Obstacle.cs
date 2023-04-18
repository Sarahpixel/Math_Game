using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector3 moveDir;         // direction to move in
    public float moveSpeed;         // speed to move at along moveDir
    private float aliveTime = 8.0f; // time before object is destroyed
                                    //private Rigidbody2D rb;
                                    //public static Obstacle Instance;
    void Start()
    {
        //Instance = this;
        //rb = this.GetComponent<Rigidbody2D>();
        Destroy(gameObject, aliveTime);
    }

    // Update is called once per frame
    void Update()
    {
        // move obstacle in certain direction over time
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        // rotate obstacle
        transform.Rotate(Vector3.back * moveDir.x * (moveSpeed * 20) * Time.deltaTime);
    }

    //public float speed = 10.0f;
    //private Rigidbody2D rb;
    //private Vector2 screenBounds;


    //// Use this for initialization
    //void Start()
    //{
    //    rb = this.GetComponent<Rigidbody2D>();
    //    rb.velocity = new Vector2(-speed, 0);
    //    screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (transform.position.x < screenBounds.x * -1)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}

