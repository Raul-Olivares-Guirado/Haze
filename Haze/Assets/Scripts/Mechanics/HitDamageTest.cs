using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamageTest : MonoBehaviour
{
    public Collider2D collider2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public int lifes = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            LosseLifeAndHit();
        }
    }

    public void LosseLifeAndHit()
    {
        lifes --;

    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
