using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesEnemy : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private AudioClip _hurt;
    public int lifes = 1;

    public void HittAndLife()
    {
        lifes--;
        animator.Play("Baddie-Hurt");
        AudioSource.PlayClipAtPoint(this._hurt, this.transform.position);
        if (lifes == 0)
        {
            animator.Play("Baddie-Death");
            Invoke("EnemyDie", 0.5f);
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
