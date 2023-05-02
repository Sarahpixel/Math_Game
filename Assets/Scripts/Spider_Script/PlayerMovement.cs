using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeed;

    private float moveHorizontal;
    private float moveVertical;

    void Start()
    {
        //gets the component thats attached to the gameobject
        rb2D = gameObject.GetComponent<Rigidbody2D>();


        //sets the movement speed 
        moveSpeed = 2f;
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
    }
}
