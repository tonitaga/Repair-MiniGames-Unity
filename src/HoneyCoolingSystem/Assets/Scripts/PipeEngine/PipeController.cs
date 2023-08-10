using System;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField]
    private PipeTypes pipeType = PipeTypes.WallPipe;

    [SerializeField]
    [Range(90, 360)]
    [Tooltip("Allowed values [90, 180, 270, 360]")]
    private int rotateAngle = 90;

    [SerializeField]
    private RotateTypes rotateType = RotateTypes.Clockwise;

    private int[][] _matrix;
    private int rotateCoefficient = -1;

    void Start()
    {
        if (rotateType == RotateTypes.CounterClockwise)
            rotateCoefficient = 1;
        rotateAngle *= rotateCoefficient;

        _matrix = new int[3][];
        for (int i = 0; i != 3; ++i)
            _matrix[i] = new int[3];
        UpdateMatrix();
    }

    public void Rotate()
    {
        gameObject.transform.Rotate(0, 0, rotateAngle);
        UpdateMatrix();

        string message = "";
        for (int i = 0; i != 3; ++i)
        {
            for (int j = 0; j != 3; ++j)
                message += _matrix[i][j] + "\t";
            message += "\n";
        }
        Debug.Log(message);

        GameWinDetector.Instance.Check();
    }

    private void UpdateMatrix()
    {
        _matrix = MatrixUpdater.Update(pipeType, (int)gameObject.transform.eulerAngles.z);
    }

    public int[][] GetMatrix()
    {
        return _matrix;
    }
}
