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

    public bool isBeingHit;

    public void Hit()
    {
        isBeingHit = true;
        playerAnimator.SetTrigger("Hit");
        InputManager.Instance.DisableInput();
        StartCoroutine(Reenable());
    }

    private IEnumerator Reenable()
    {
        yield return new WaitForSeconds(freezeDuration);
        InputManager.Instance.EnableInput();
        isBeingHit = false;
    }
}