using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifes : MonoBehaviour
{
    public Animator animator;
    //public SpriteRenderer spriteRenderer;
    public int lifes = 1;

    public void HittAndLifePlayer()
    {
        lifes--;
        animator.Play("Player-Hurt");

        if (lifes == 0)
        {
            animator.Play("Player-Death");
            //Invoke("EnemyDie", 0.05f);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
