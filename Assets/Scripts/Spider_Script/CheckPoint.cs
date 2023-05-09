using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameBehaviour _gB;
    public Transform respawnPoint;

    Collider2D coll;
    private void Awake()
    {
        _gB = GameObject.FindGameObjectWithTag("Player").GetComponent<GameBehaviour>();
        coll = GetComponent<Collider2D>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _gB.UpdateCheckPoint(respawnPoint.position);
            coll.GetComponent<Animator>().SetTrigger("appear"); // trigger the animation once the player collides with the checkpoint
            coll.enabled = false; // disables gthe collider once the player collides with it once, so that the player can't interact with it the 2nd time when respawning
        }
    }
}
