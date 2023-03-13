using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlvidoTokenCollect : MonoBehaviour
{

    [SerializeField]
    private TimerController timerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timerController.DisabledTimer();
            collision.gameObject.GetComponent<PlayerController>().controlEnabled = true;
            timerController.time.enabled = false;
            Destroy(gameObject);
            //collision.gameObject.GetComponent<AttackOlivido>().Destroy();
            //InvokeRepeating("Timer", 0f, 1f);
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
