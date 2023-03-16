using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{

    public Collider2D _collider2D;
    public Animator animator;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            
            animator.Play("Baddie-Hurt");
            Invoke("EnemyDie", 0.1f);

        }
    }

    public void LosseLifeAndHit()
    {
        //lifes--;
        //animator.Play("EnemyHurt");
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }

}
