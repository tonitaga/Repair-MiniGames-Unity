using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static int _currentSceneIndex = 0;
    private static int _savedSceneIndex = 0;

    void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;    
    }

    public void LoadNextScene()
    {
        GameController.ResumeGame();
        try
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public void LoadSceneByBuildIndex(int buildIndex)
    {
        GameController.ResumeGame();
        _savedSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _currentSceneIndex = buildIndex;
        SceneManager.LoadScene(buildIndex);
    }

    public void LoadSceneByName(string name)
    {
        GameController.ResumeGame();
        _savedSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _currentSceneIndex = SceneManager.GetSceneByName(name).buildIndex;
        SceneManager.LoadScene(name);
    }

    public void LoadSavedScene()
    {
        GameController.ResumeGame();
        _currentSceneIndex = _savedSceneIndex;
        SceneManager.LoadScene(_savedSceneIndex);
    }
}
