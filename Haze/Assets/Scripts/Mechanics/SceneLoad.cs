using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [SerializeField]
    private float sceneLoadDelay = 1f;

    private int[] _sceneIndex = {0,1,2,3,4,5};
    public void GameOver()
    {
        DelayedLoadLevel(_sceneIndex[3], sceneLoadDelay);
    }

    public void Victory()
    {
       DelayedLoadLevel(_sceneIndex[4], sceneLoadDelay);
    }

    public void MainMenu()
    {
        DelayedLoadLevel(_sceneIndex[0], sceneLoadDelay);
    }

    public void Options()
    {
        DelayedLoadLevel(_sceneIndex[5], sceneLoadDelay);
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

}
