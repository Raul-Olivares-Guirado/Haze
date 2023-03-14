using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazeEnemy : MonoBehaviour
{

    public TimerController timerController;
    public Health health;
    private PlayerAtack playerAttack;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timerController.EnabledTimer();
            timerController.time.enabled = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timerController.DisabledTimer();
            timerController.time.enabled = false;
            
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
