using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlvidoTokenCollect : MonoBehaviour
{
    [SerializeField] private AudioClip tokenOlvido;


    public GameObject OlvidoLayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().controlEnabled = true;
            Destroy(gameObject);
            OlvidoLayer.SetActive(false);
            AudioSource.PlayClipAtPoint(this.tokenOlvido, this.transform.position);
        }
    }


}
