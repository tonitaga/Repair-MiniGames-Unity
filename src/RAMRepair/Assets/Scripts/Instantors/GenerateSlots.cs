using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSlots : MonoBehaviour
{
    [SerializeField]
    private GameObject generatingSlot = null;

    [SerializeField]
    [Range(0, 6)]
    private int countOfSlots = 5;

    [SerializeField]
    [Tooltip("Generating start point")]
    private float leftBorder = -10.0f;

    [SerializeField]
    [Tooltip("Generating end point")]
    private float rightBorder = 10.0f;

    [SerializeField]
    [Tooltip("Generating Slots YAxis position")]
    private float generatingYAxisCoord = 0.0f;

    private float distance = 0.0f;

    void Awake()
    {
        distance = rightBorder - leftBorder;
        Generate();
    }

    void Generate()
    {
        float positionDelta = distance / countOfSlots;

        for (int i = 0; i != countOfSlots; ++i)
        {
            Instantiate(generatingSlot, new Vector3(leftBorder + i * positionDelta + Random.Range(0.0f, positionDelta / 2.5f), generatingYAxisCoord, 0), new Quaternion());
        }
    }
}
