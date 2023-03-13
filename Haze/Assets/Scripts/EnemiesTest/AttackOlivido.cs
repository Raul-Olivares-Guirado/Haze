using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Platformer.Mechanics;

public class AttackOlivido : MonoBehaviour
{
    [SerializeField]
    private TimerController timerController;

    public Animator animator;

    public Collider2D _Collider2D;

    public GameObject OlvidoLayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().controlEnabled = false;
            OlvidoLayer.SetActive(true);
        }
        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
