using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour
{
    public static GameEndController instance;

    [SerializeField]
    private GameObject gameWinPanel = null;

    [SerializeField]
    private GameObject gameLosePanel = null;

    [SerializeField]
    [Range(0.0f, 100.0f)]
    [Tooltip("Current accuracy % for win")]
    private float gameWinMinimumScore = 90.0f;

    private TextMeshProUGUI textMeshProWin = null;
    private TextMeshProUGUI textMeshProLose = null;

    void Start()
    {
        textMeshProWin = gameWinPanel.GetComponentInChildren<TextMeshProUGUI>();
        if (textMeshProWin == null)
            Debug.LogWarning("Error! textMeshProWin");

        textMeshProLose = gameLosePanel.GetComponentInChildren<TextMeshProUGUI>();
        if (textMeshProWin == null)
            Debug.LogWarning("Error! textMeshProLose");

        instance = this;
    }

    public void ShowGameEndPanel(float accuracy)
    {
        if (gameWinPanel == null || textMeshProWin == null || gameLosePanel == null || textMeshProLose == null)
            return;

        if (accuracy > gameWinMinimumScore)
        {
            textMeshProWin.text = "Точность: " + (Mathf.Floor(accuracy / 0.1f) * 0.1f).ToString() + "%";
            gameWinPanel.SetActive(true);
        } else
        {
            textMeshProLose.text = "Точность: " + (Mathf.Floor(accuracy / 0.1f) * 0.1f).ToString() + "%";
            gameLosePanel.SetActive(true);
        }
    }

}
