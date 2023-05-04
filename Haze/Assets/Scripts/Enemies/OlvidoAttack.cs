using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField, Tooltip("Tiempo inicial en segundos")] 
    private int _initialTime;
    [SerializeField, Tooltip("Calcula la escala que tiene el tiempo, si resta o suma")] 
    private float _countScale = -1f; //Es el valor que va a restar, sumar o pausar el tiempo
    [SerializeField]
    private bool _countActive = false;

    private float _countFrameWithTimeScale = 0f;
    private float _countSecondsToShow = 0f;

    private float _countPaused, _countStart;

    public TextMeshProUGUI time;
    public Collider2D _collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().controlEnabled = false;
            _countActive = true;
            StartTimer();
            //_countActive = true;
            /*if (_countActive == true)
            {
                InvokeRepeating("StartTimer", 0f, 1f);
            }*/

        }
    }

    //Inicia el contador
    public void StartTimer()
    {
        if (_countActive == true) //Detecta que no es falso
        {
            time.enabled = true;


            //_countActive = true; //Pone la condicion a true

            _countPaused = _countScale; //El valor pausado va a detectar si esta activo

            _countScale = -1f; //Hacemos que el valor sea 0 para que no este activo, ni reste ni sume
        }
    }

    //Pausa el tiempo
    public void PauseTimer()
    {
        if (!_countActive) //Detecta que no es falso
        {
            _countActive = true; //Pone la condicion a true
            
            _countPaused = _countScale; //El valor pausado va a detectar si esta activo

            _countScale = 0f; //Hacemos que el valor sea 0 para que no este activo, ni reste ni sume
        }
    }

    //Descactiva la pausa y continua con el tiempo
    public void ContinueTimer()
    {
        if (_countActive)
        {
            _countActive = false;
            
            _countScale = _countPaused;
        }
    }

    public void RestartTimer()
    {

        _countActive = false;

        _countScale = _countStart;

        _countSecondsToShow = _initialTime;

        UpdateCount(_countSecondsToShow);

    }

    public void UpdateCount(float secondsTime)
    {
        int minutes = 0;
        int seconds = 0;
        string textTime;
        if(secondsTime < 0)
        {
            secondsTime = 0;
        }

        minutes = (int)secondsTime / 60;
        seconds = (int)secondsTime % 60;

        textTime = minutes.ToString("00") + ":" + seconds.ToString("00");

        time.text = textTime;

    }

    // Start is called before the first frame update
    void Start()
    {
        time.enabled = false;

        _countStart = _countScale;

        _countSecondsToShow = _initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_countActive == true)
        {
            _countFrameWithTimeScale = Time.deltaTime * _countScale;
            _countSecondsToShow += _countFrameWithTimeScale;
            UpdateCount(_countSecondsToShow);
        }

    }
}
