using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicaManager : MonoBehaviour
{
    public float timeStart;
    public float timeEnd = 20f;
    [SerializeField]
    private SceneLoad _nextScene;

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;

        if (timeStart >= timeEnd)
        {
            _nextScene.LoadNextScene();
        }
    }
}
