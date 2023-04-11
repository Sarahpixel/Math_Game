using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemTube : MonoBehaviour
{
    public int tubeId;  // identifier number for this tube

    // called when something enters the tube's collider
    void OnTriggerEnter2D (Collider2D other)
    {
        // was it the player?
        if(other.CompareTag("Player"))
        {
            // tell the game manager that the player entered this tube
            GameManager.instance.OnPlayerEnterTube(tubeId);
        }
    }
    
}