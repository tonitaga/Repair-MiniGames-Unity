using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    static public void Start()
    {
        Time.timeScale = 1.0f;
    }

    static public void Stop()
    {
        Time.timeScale = 0.0f;
    }
}
