using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public int health = 3;
    public TextMeshProUGUI healthText;
    public AudioClip damageSound;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Debug.LogError("Player RB not found");
        }

        healthText.text = health + "/3 Health";
    }

    private void FixedUpdate()
    {
       if (GameManager.instance.isPaused)
        {
            return;
        }
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    public void TakeDamage(int damageValue)
    {
        health -= damageValue;
        AudioSource.PlayClipAtPoint(damageSound, transform.position, 1f);
        healthText.text = health + "/3 Health";
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    
}
