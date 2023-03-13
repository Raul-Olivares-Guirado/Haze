using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public Animator animator;
    //public SpriteRenderer spriteRenderer;
    public int lifes = 1;

    public void HittAndLife()
    {
        lifes--;
        animator.Play("Player-Hurt");

        if (lifes == 0)
        {
            animator.Play("Player-Death");
            Invoke("PlayerDie", 1f);
        }
    }

    public void PlayerDie()
    {
        Destroy(gameObject);
    }

}
