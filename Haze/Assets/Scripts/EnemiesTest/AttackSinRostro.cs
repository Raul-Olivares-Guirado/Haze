using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSinRostro : MonoBehaviour
{
   
    public TakeDamage takeDamage;
    [SerializeField]private AudioClip ouch;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            takeDamage.HittAndLife();
            collision.gameObject.GetComponent<PlayerController>().audioSource.PlayOneShot(ouch);
        }
    }

}
