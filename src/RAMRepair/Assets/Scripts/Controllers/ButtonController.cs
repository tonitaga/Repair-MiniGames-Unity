using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        TimeController.Start();
    }

    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
        TimeController.Start();
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
