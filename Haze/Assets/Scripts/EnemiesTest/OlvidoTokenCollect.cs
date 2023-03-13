using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlvidoTokenCollect : MonoBehaviour
{
    public GameObject OlvidoLayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().controlEnabled = true;
            Destroy(gameObject);
            OlvidoLayer.SetActive(false);

        }
    }


}
