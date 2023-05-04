using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSinRostro : MonoBehaviour
{
   
    public TakeDamage takeDamage;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            takeDamage.HittAndLife();
        }
    }

}
