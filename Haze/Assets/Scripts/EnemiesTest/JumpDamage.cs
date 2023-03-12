using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{

    public Collider2D _collider2D;
    public Animator animator;
    //public SpriteRenderer spriteRenderer;
    //public GameObject destroyParticle;
    //public float jumpForce = 2.5f;
    //public int lifes = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<BoxCollider2D>();
            //destroyParticle.SetActive(true);
            animator.Play("Baddie-Hurt");
            Invoke("EnemyDie", 0.1f);
            //LosseLifeAndHit();
            //CheckLife();
        }
    }

    public void LosseLifeAndHit()
    {
        //lifes--;
        //animator.Play("EnemyHurt");
    }

    public void CheckLife()
    {
        /*if (lifes == 0)
        {
            //animator.Play("EnemyDeath");
            //destroyParticle.SetActive(true);
            //spriteRenderer.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }*/
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }

}
