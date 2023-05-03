using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Platformer.Mechanics;

public class AttackOlivido : MonoBehaviour
{

    public Collider2D _Collider2D;

    //Layer de tokens Olvido para revertir los controles
    public GameObject OlvidoLayer;
    //Layer del objeto entero para destruirlo cuando lo tocamos
    public GameObject OlvidoEnemy;

    public Animator animator;

    [SerializeField] private AudioClip ouch;
    [SerializeField] private AudioClip _death;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().controlEnabled = false;
            collision.gameObject.GetComponent<PlayerController>().audioSource.PlayOneShot(ouch);
            AudioSource.PlayClipAtPoint(this._death, this.transform.position);
            OlvidoLayer.SetActive(true);
            animator.Play("Baddie-Death");
            Invoke("DestroyEnemy", 0.5f);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(OlvidoEnemy);
    }

}
