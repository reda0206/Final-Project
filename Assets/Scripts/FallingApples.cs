using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingApples : MonoBehaviour
{
    public float fallSpeed = 2f;
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = 4f;
    public float maxY = 6f;
    public AudioClip appleSound;

    private void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(appleSound, transform.position, 1f);
            GameManager.instance.CollectApples();            
            TeleportToRandomPosition();
            fallSpeed = fallSpeed + 0.1f;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {       
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            TeleportToRandomPosition();
        }
    }

    private void TeleportToRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        transform.position = new Vector2(randomX, randomY);
    }
}
