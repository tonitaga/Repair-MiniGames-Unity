using System;
using UnityEngine;

public class GameWinDetector : MonoBehaviour
{
    private int[,] _matrix = null;

    private int _rows = -1, _cols = -1;

    [SerializeField]
    private GameObject showingPanel = null;

    [SerializeField]
    [Range(0, 20)]
    private int start_col = 0, finish_col = 0;

    [SerializeField]
    [Range(0, 10)]
    private int start_row = 0, finish_row = 0;

    public static GameWinDetector Instance;

    void Start()
    {
        Instance = this;
    }

    public void Check()
    {
        MakeSceneMatrix();
        WaveAlgorithm wave = new WaveAlgorithm(_matrix, _rows, _cols);
        if (wave.Solve(new Point(start_row, start_col), new Point(finish_row, finish_col)))
        {
            if (showingPanel != null)
            {
                showingPanel.SetActive(true);
                GameController.StopGame();
            }
        }
    }

    private void MakeSceneMatrix()
    {
        var pipes = PipeContainer.Instance.GetPipes();
        int rows = pipes.Count;
        int cols = PipeContainer.Instance.GetItemsCount() / rows;
        _rows = rows * 3;
        _cols = cols * 3;

        _matrix = new int[_rows, _cols];

        int row_step = 0;
        for (int i = 0; i != rows; ++i)
        {
            int col_step = 0;
            for (int j = 0; j != cols; ++j)
            {
                int[][] pipe_matrix = pipes[i][j].GetComponent<PipeController>().GetMatrix();

                if (pipe_matrix == null)
                    break;

                _matrix[row_step + 0, col_step + 0] = pipe_matrix[0][0];
                _matrix[row_step + 0, col_step + 1] = pipe_matrix[0][1];
                _matrix[row_step + 0, col_step + 2] = pipe_matrix[0][2];
                _matrix[row_step + 1, col_step + 0] = pipe_matrix[1][0];
                _matrix[row_step + 1, col_step + 1] = pipe_matrix[1][1];
                _matrix[row_step + 1, col_step + 2] = pipe_matrix[1][2];
                _matrix[row_step + 2, col_step + 0] = pipe_matrix[2][0];
                _matrix[row_step + 2, col_step + 1] = pipe_matrix[2][1];
                _matrix[row_step + 2, col_step + 2] = pipe_matrix[2][2];

                col_step += 3;
            }
            row_step += 3;
        }
    }
}
