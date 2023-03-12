using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Platformer.Mechanics;

public class AttackOlivido : MonoBehaviour
{
     public float timer = 5f;

    public TextMeshProUGUI timerText;

    public Collider2D _collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().controlEnabled = false;
            InvokeRepeating("Timer", 0f, 1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //timerText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0f)
        {
            //timer = 0f;
            timerText.enabled = false;
           
        }
        //timer -= Time.deltaTime;

        //timerText.text = "" + timer.ToString("f0");
    }

    public void Timer()
    {
        timer--;
        timerText.text = "" + timer.ToString("f0");
    }
}
