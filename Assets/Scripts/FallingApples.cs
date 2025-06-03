using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingApples : MonoBehaviour
{
    public float fallSpeed = 2f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollectApples();
            Destroy(gameObject);
            fallSpeed = 2f + 0.1f;
        }
    }
}
