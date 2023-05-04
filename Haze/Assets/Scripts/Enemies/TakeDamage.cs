using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using UnityEngine;


public class TakeDamage : MonoBehaviour
{
    public Animator animator;
    public GameObject[] heartsImage; 
    public int lifes = 1;
    [SerializeField, Tooltip("Col·locar el script SceneLoad per referenciar el GameOver")]
    //Referencia al GameOver
    private SceneLoad _gO;
    [SerializeField] private AudioClip hurt;
    [SerializeField] private AudioClip death;
    public void HittAndLife()
    {
        lifes--;
        animator.Play("Player-Hurt");
        
        if (lifes < 3)
        {
            Destroy(heartsImage[2].gameObject);
            AudioSource.PlayClipAtPoint(this.hurt, this.transform.position);
        }
        if (lifes < 2)
        {
            Destroy(heartsImage[1].gameObject);
            AudioSource.PlayClipAtPoint(this.hurt, this.transform.position);
        }
        if (lifes == 0)
        {
            animator.Play("Player-Death");
            Destroy(heartsImage[0].gameObject);
            Invoke("PlayerDie", 1.5f);
            AudioSource.PlayClipAtPoint(this.death, this.transform.position);
        }

    }

    public void PlayerDie()
    {
        Destroy(gameObject);
        _gO.GameOver();
    }

}
