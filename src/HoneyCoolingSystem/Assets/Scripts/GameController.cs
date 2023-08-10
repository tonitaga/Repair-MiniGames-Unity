using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static void StopGame()
    {
        Time.timeScale = 0.0f;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1.0f;
    }
}
