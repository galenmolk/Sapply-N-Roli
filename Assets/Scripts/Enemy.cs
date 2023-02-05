using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;
using GGJ;

public class Enemy : MonoBehaviour
{
    public float threshold;
    public float speed;

    public Rigidbody2D rb;
    public Rigidbody2D playerRb;

    public bool isChasing;

    public float disappearSpeed;

    public void OnHitPlayer()
    {
        Debug.Log("Hit Player");
        SoundEffects.Instance.EnemyHit();
        InventoryManager.Instance.DestroyResources();
        Player.Instance.Hit();

        transform.DOScale(0f, disappearSpeed).OnComplete(() => {
            Destroy(gameObject);
        });
    } 

    private void Update()
     {
        isChasing = Vector2.Distance(rb.position, Player.Instance.RBPos) < threshold;
    }

    private void FixedUpdate() 
    {
        if (isChasing)
        {
            Chase();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void Chase()
    {
        Vector2 direction = playerRb.position - rb.position;
        rb.velocity = direction.normalized * speed;
    }
}
