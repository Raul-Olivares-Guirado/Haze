using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Platformer.Mechanics;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    private float _timeMax;
    public float _timeActual;
    public bool timeActive = false;

    public TextMeshProUGUI time;
    public TakeDamage takeDamage;

    // Start is called before the first frame update
    void Start()
    {
        //EnabledTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeActive)
        {
            ChangeCount();
        }
    }

    public void ChangeCount()
    {
        _timeActual -= Time.deltaTime;

        if (_timeActual >= 0)
        {
            time.text = "" + _timeActual.ToString("f0");
        }

        if (_timeActual <= 0)
        {
            ChangeTimer(false);
            Debug.Log("Lose / Death / Anything");
            time.enabled = false;
            takeDamage.HittAndLife();
        }
    }

    public void ChangeTimer(bool estate)
    {
        timeActive = estate;
    }

    public void EnabledTimer()
    {
        _timeActual = _timeMax;
        time.text = "" + _timeMax.ToString("f0");
        ChangeTimer(true);
    }

    public void DisabledTimer()
    {
        ChangeTimer(false);
    }
}
