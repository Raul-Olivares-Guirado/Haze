using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesEnemy : MonoBehaviour
{
    public Animator animator;
    //public SpriteRenderer spriteRenderer;
    public int lifes = 1;

    public void HittAndLife()
    {
        lifes--;
        animator.Play("Baddie-Hurt");

        if (lifes == 0)
        {
            animator.Play("Baddie-Death");
            Invoke("EnemyDie", 0.05f);
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
