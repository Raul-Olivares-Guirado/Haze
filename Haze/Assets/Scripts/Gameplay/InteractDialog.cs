using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractDialog : MonoBehaviour
{
    private bool playerRange;
    private bool dialogueStart;
    private int lineIndex;
    //Sprite exclamacion
    [SerializeField]
    private GameObject dialogExclamation;
    //Panel que envuelve el texto
    [SerializeField]
    private GameObject dialoguePanel;
    //Texto que mostraremos
    [SerializeField]
    private TMP_Text dialogueText;
    //Array con los dialogos
    //TextArea me deja hacer grande la caja para escribir el dialogo
    [SerializeField, TextArea(4,6)]
    private string[] dialogText;


    // Update is called once per frame
    void Update()
    {
        if(playerRange && Input.GetKeyDown(KeyCode.F))
        {
            if (!dialogueStart)
            {
                StartDialogue();
            }
            // Si el texto esta mostrando la conversacion completa, pasa a la siguiente linea
            else if (dialogueText.text == dialogText[lineIndex]) 
            {
                NextLineDialogue();
            }
            // Si aprietas la tecla de interaccion y el texto no esta completo se paran las corrutinas
            // Sirve para adelantarte y no esperar a que salga todo el texto por tiempo
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogText[lineIndex];
            }
            
        }
    }
    // Metodo que inicia el dialogo 
    private void StartDialogue()
    {
        dialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogExclamation.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    // Metodo para pasar a la siguiente linea del texto
    private void NextLineDialogue()
    {
        lineIndex++;
        if (lineIndex < dialogText.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            dialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogExclamation.SetActive(true);
            Time.timeScale = 1.0f;
        }
    }

    //Corrutina que hace que cada linea de texto salga con un retardo y no todo de golpe
    IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach(char ch in dialogText[lineIndex])
        {
            dialogueText.text += ch;
            //Utilizo el WaitForSecondsRealTime para ignorar cuando paro el tiempo para que se detenga el player
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRange = true;
            dialogExclamation.SetActive(true);
            Debug.Log("A entrado, apreta F para ver");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRange = false;
            dialogExclamation.SetActive(false);
            Debug.Log("A salido");
        }
    }
}
