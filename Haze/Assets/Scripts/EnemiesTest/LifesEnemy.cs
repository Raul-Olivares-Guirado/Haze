using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesEnemy : MonoBehaviour
{
    public Animator animator;
    //public SpriteRenderer spriteRenderer;
    public int lifes = 1;

    //Metode que resta vidas
    public void HittAndLife()
    {
        lifes--;
        animator.Play("Baddie-Hurt");
        
        //Cuando las vidas llegan a 0 muere
        if (lifes == 0)
        {
            animator.Play("Baddie-Death");
            Invoke("EnemyDie", 0.05f);
        }
    }

    //Metodo que elimina el game object pero que lo usare con un invoke
    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
