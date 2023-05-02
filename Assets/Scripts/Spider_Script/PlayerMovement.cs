using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeed;
    //private float jumpForce;
    //private bool isJumping;


    private float moveHorizontal;
    private float moveVertical;

    void Start()
    {
        //gets the component thats attached to the gameobject
        rb2D = gameObject.GetComponent<Rigidbody2D>();


        //sets the movement speed 
        moveSpeed = 1;

        //jumpForce = 20;
        //isJumping = false;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }
        //if (!isJumping && moveVertical > 0.1f)
        //{
        //    rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        //}
    }
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Floor")
    //    {
    //        isJumping = false;
    //    }
    //}
    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Floor")
    //    {
    //        isJumping = true;
    //    }
    //}
}
