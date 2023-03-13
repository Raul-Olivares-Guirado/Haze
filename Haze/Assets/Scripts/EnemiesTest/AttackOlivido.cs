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

    //public float timer = 5f;

    //public bool start = false;

    //public TextMeshProUGUI timerText;

    public Collider2D _collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timerController.EnabledTimer();
            collision.gameObject.GetComponent<PlayerController>().controlEnabled = false;
            //InvokeRepeating("Timer", 0f, 1f);
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
        //timer -= Time.deltaTime;

        //timerText.text = "" + timer.ToString("f0");
    }

    /*public void Timer()
    {
        timer--;
        timerText.text = "" + timer.ToString("f0");
    }*/

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void OlvidoAttack()
    {
        animator.Play("Player-Hurt");
    }

}
