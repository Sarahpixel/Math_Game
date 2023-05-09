using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    Vector2 checkPointPos;
    Rigidbody2D playerRb;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerRb= GetComponent<Rigidbody2D>();
        spriteRenderer =  GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        checkPointPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }
    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }
    public void UpdateCheckPoint(Vector2 pos)
    {
        checkPointPos= pos;
    }
    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;
        playerRb.velocity = new Vector2(0,0);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = checkPointPos;
        spriteRenderer.enabled = true;
        playerRb.simulated = true;
    }
   
}
