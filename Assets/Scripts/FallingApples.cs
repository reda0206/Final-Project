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

    private PlayerMovement playerScript;

    private void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

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
            fallSpeed = fallSpeed + 0.2f;
        }

        else if (collision.gameObject.CompareTag("Ground"))
        {       
            Debug.Log("Apple hit the ground");
            playerScript.TakeDamage(1);
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
