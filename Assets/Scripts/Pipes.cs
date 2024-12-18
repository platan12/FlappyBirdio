using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f; // Velocitat constant cap a l'esquerra
    private Rigidbody2D rb;
    private bool Stop = false;

    void Start()
    {
        // Agafa el Rigidbody2D del mateix objecte
        rb = GetComponent<Rigidbody2D>();

        // Comprova si el Rigidbody2D està assignat
        if (rb == null)
        {
            Debug.LogError("No hi ha Rigidbody2D assignat!");
        }
    }

    void FixedUpdate()
    {
        if (!Stop)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        } else
        {
           Debug.Log("Stop");
           rb.velocity = Vector2.zero;
           Debug.Log(rb.velocity);
        }
        
    }
    public void StopPipes() 
    {   
        Debug.Log("Stopping pipes");
        Stop = true;
       
    }
}