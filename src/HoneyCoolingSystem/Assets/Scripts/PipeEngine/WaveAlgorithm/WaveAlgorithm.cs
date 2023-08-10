using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveAlgorithm
{
    private int[,] _matrix;
    private int _rows, _cols;

    private int[,] _length_map;
    private int _wave_step;
    private const int _empty_value = Int32.MinValue;

    private List<Point> _wave, _old_wave;

    public WaveAlgorithm(int[,] matrix, int rows, int cols)
    {
        _matrix = matrix;
        _length_map = new int[rows, cols];
        _wave = new List<Point>();
        _old_wave = new List<Point>();
        _rows = rows;
        _cols = cols;
    }

    public bool Solve(Point from, Point to)
    {
        InitializeStartState(from);

        while (_old_wave.Count != 0)
            if (StepWave(to))
                break;

        bool answer = true;
        if (_length_map[to.row, to.col] == _empty_value)
            answer = false;

        DebugLengthMatrix();
        return answer; 
    }

    void InitializeStartState(Point from)
    {
        _wave.Clear();
        _wave_step = 0;
        _old_wave = new List<Point> { from };
        _length_map = new int[_rows, _cols];
        for (int i = 0; i != _rows; ++i)
            for (int j = 0; j != _cols; ++j)
                _length_map[i, j] = _empty_value;

        _length_map[from.row, from.col] = _wave_step;
    }
    bool StepWave(Point to)
    {
        ++_wave_step;
        for (int i = 0; i != _old_wave.Count; ++i)
        {
            int row = _old_wave[i].row;
            int col = _old_wave[i].col;

            List<SidePoint> neighbors = GetNeighbors(row, col);
            foreach (var neighbor in neighbors)
            {
                if (neighbor.value == 0)
                {
                    if (_length_map[neighbor.x, neighbor.y] == _empty_value)
                    {
                        _wave.Add(new Point(neighbor.x, neighbor.y));
                        _length_map[neighbor.x, neighbor.y] = _wave_step;
                    }

                    if (neighbor.x == to.row && neighbor.y == to.col)
                        return true;
                }
            }
        }
        _old_wave = new List<Point>(_wave);
        _wave.Clear();
        return false;
    }

    List<SidePoint> GetNeighbors(int row, int col)
    {
        List<SidePoint> neighbors = new List<SidePoint>();
        if (row != _rows - 1)
            neighbors.Add(new SidePoint(row + 1, col, _matrix[row + 1, col]));
        if (row != 0)
            neighbors.Add(new SidePoint(row - 1, col, _matrix[row - 1, col]));
        if (col != _cols - 1)
            neighbors.Add(new SidePoint(row, col + 1, _matrix[row, col + 1]));
        if (col != 0)
            neighbors.Add(new SidePoint(row, col - 1, _matrix[row, col - 1]));

        return neighbors;
    }

    void DebugLengthMatrix()
    {
        string message = "";
        for (int i = 0; i != _rows; ++i)
        {
            for (int j = 0; j != _cols; ++j)
            {
                if (_length_map[i, j] == _empty_value)
                    message += "x\t";
                else
                    message += _length_map[i, j] + "\t";
            }
            message += '\n';

        }
        Debug.Log(message);
    }
}