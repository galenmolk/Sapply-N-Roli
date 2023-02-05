using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;
using GGJ;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float threshold;
    public float speed;
    public float startingSpeed;

    public Rigidbody2D rb;
    public Rigidbody2D playerRb;

    public bool isChasing;
    public Collider2D coll;

    public float disappearSpeed;
    public UnityEvent onDie;

    public void OnHitPlayer()
    {
        if (Player.Instance.isBeingHit)
        {
            return;
        }

        Player.Instance.Hit();
        Debug.Log("Hit Player");
        coll.enabled = false;
        SoundEffects.Instance.EnemyHit();
        InventoryManager.Instance.DestroyResources();

        transform.DOScale(0f, disappearSpeed).OnComplete(() => 
        {
            gameObject.SetActive(false);
            onDie?.Invoke();
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
        Vector2 direction = Player.Instance.RBPos - rb.position;
        rb.velocity = direction.normalized * speed;
    }

    private void Start() {
         speed = startingSpeed;
    }
}
