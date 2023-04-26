using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [SerializeField]
    private float sceneLoadDelay = 1f;

    private int[] _sceneIndex = {0,1,2,3,4,5};

    [SerializeField] Animation fadeAnimation;
    [SerializeField] AnimationClip fadeOutAnimationClip;
    [SerializeField] AnimationClip fadeInAnimationClip;

    /*
    private static SceneLoad _instance;

    public static SceneLoad Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }*/

    public void Start()
    {
        FadeIn();
    }
    public void GameOver()
    {
        DelayedLoadLevel(_sceneIndex[4], sceneLoadDelay);
        FadeOut();
    }

    public void Victory()
    {
       DelayedLoadLevel(_sceneIndex[3], sceneLoadDelay);
        FadeOut();
    }

    public void MainMenu()
    {
        DelayedLoadLevel(_sceneIndex[0], sceneLoadDelay);
        FadeOut();
    }

    public void Options()
    {
        DelayedLoadLevel(_sceneIndex[5], sceneLoadDelay);
        FadeOut();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Sortint del joc!!!!");
    }

    public void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        DelayedLoadLevel(sceneIndex, sceneLoadDelay);
        FadeOut();
    }

    private void DelayedLoadLevel(int index, float delay)
    {
        StartCoroutine(WaitAndLoad(index, delay));
    }

    IEnumerator WaitAndLoad(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(index);
    }

    private void FadeOut()
    {
        fadeAnimation.clip = fadeOutAnimationClip;
        fadeAnimation.Play();
    }

    private void FadeIn()
    {
        fadeAnimation.clip = fadeInAnimationClip;
        fadeAnimation.Play();
    }

}
