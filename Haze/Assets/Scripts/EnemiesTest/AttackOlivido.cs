using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Platformer.Mechanics;

public class AttackOlivido : MonoBehaviour
{

    public Collider2D _Collider2D;

    public GameObject OlvidoLayer;

    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().controlEnabled = false;
            OlvidoLayer.SetActive(true);
            animator.Play("Baddie-Hurt");
            Invoke("DestroyEnemy", 0.1f);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}
