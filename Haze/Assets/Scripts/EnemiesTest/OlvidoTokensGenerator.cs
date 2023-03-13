using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlvidoTokensGenerator : MonoBehaviour
{
    public GameObject OlvidoLayer;
    public GameObject[] OlvidoTokens;
    // Start is called before the first frame update
    void Start()
    {
        OlvidoLayer.SetActive(false);
    }

}
