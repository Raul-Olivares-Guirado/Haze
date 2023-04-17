using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color hoverColor;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponentInChildren<TMP_Text>();
        _text.color = defaultColor;
    }

    // ALERTA! no es criden automàticament quan s'utilitza només el nou InputSystem
    public void OnMouseEnter()
    {
        _text.color = hoverColor;
        
    }

    public void OnMouseExit()
    {
        _text.color = defaultColor;
    }

}
