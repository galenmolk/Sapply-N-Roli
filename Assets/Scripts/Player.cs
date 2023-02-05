using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BramblyMead;

public class Player : Singleton<Player>
{
    public Vector2 RBPos => rb.position;

    public Rigidbody2D rb;

    public  Animator playerAnimator;

    public void Hit()
    {
        playerAnimator.SetTrigger("Hit");
    }
}
