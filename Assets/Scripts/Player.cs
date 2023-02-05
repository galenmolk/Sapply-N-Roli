using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BramblyMead;
using GGJ;

public class Player : Singleton<Player>
{
    public Vector2 RBPos => rb.position;

    public Rigidbody2D rb;

    public  Animator playerAnimator;

    public float freezeDuration;
    public Collider2D coll;
    public RigidbodyController rigidbodyController;

    public bool isBeingHit;

    public void Hit()
    {
        rigidbodyController.ignoreInput = true;
        rb.velocity = Vector2.zero;
        coll.enabled = false;
        isBeingHit = true;
        playerAnimator.SetTrigger("Hit");
        StartCoroutine(Reenable());
    }

    private IEnumerator Reenable()
    {
        yield return new WaitForSeconds(freezeDuration);
        coll.enabled = true;
        isBeingHit = false;
        rigidbodyController.ignoreInput = false;
    }
}
