using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{

    public Collider2D _collider2D;
    public Animator animator;
    [SerializeField] private AudioClip _hurt;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            foreach (ContactPoint2D punto in other.contacts)
            {
                if (punto.normal.y <= -0.9)
                {
                    animator.Play("Baddie-Hurt");
                    AudioSource.PlayClipAtPoint(this._hurt, this.transform.position);
                    Invoke("EnemyDie", 0.4f);
                }
            }

        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }

}
