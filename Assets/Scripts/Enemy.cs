using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float threshold;
    public float speed;

    public Rigidbody2D rb;
    public Rigidbody2D playerRb;

    private void FixedUpdate() 
    {
        Vector2 direction = playerRb.position - rb.position;
        rb.velocity = direction.normalized * speed;
    }
}
