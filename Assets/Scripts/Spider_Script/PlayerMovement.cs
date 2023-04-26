using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpiderState
{
    Idle,       // 0
    Walking,    // 1
    Stunned     // 2
}
public class PlayerMovement : MonoBehaviour
{
    public SpiderState curState;            // current player state

    // values
    public float moveSpeed;                 // force applied horizontally when moving
    public bool grounded;                   // is the player currently standing on the ground?
    public float stunDuration;              // duration of a stun
    private float stunStartTime;            // time that the player was stunned

    // components
    public Rigidbody2D rig;                 // Rigidbody2D component
    public Animator anim;                   // Animator component

    void Move()
    {
        // get horizontal axis (A & D, Left Arrow & Right Arrow)
        float dir = Input.GetAxis("Horizontal");

        // flip player to face the direction they're moving
        if (dir > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (dir < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // set rigidbody horizontal velocity
        rig.velocity = new Vector2(dir * moveSpeed, rig.velocity.y);
    }
    // returns true if player is on ground, false otherwise
    bool IsGrounded()
    {
        // shoot a raycast down underneath the player
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.85f), Vector2.down, 0.3f);

        // did we hit anything?
        if (hit.collider != null)
        {
            // was it the floor?
            if (hit.collider.CompareTag("Floor"))
            {
                return true;
            }
        }

        return false;
    }
    void CheckInputs()
    {
        if (curState != SpiderState.Stunned)
        {
            Move();
        }
    }
    // sets the player's state
    void SetState()
    {
        // don't worry about changing states if the player's stunned
        if (curState != SpiderState.Stunned)
        {
            // idle
            if (rig.velocity.magnitude == 0 && grounded)
                curState = SpiderState.Idle;
            // walking
            if (rig.velocity.x != 0 && grounded)
                curState = SpiderState.Walking;
           
        }

        // tell the animator we've changed states
        anim.SetInteger("State", (int)curState);
    }
    // called when the player gets stunned
    public void Stun()
    {
        curState = SpiderState.Stunned;
        rig.velocity = Vector2.down * 3;
        stunStartTime = Time.time;
       
    }
    void FixedUpdate()
    {
        grounded = IsGrounded(); 
        CheckInputs();
    }
}
