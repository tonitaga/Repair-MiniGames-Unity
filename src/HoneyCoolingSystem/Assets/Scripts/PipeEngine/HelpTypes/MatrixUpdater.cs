
public class MatrixUpdater
{

    static public int[][] Update(PipeTypes type, int angle)
    {
        int[][] matrix = CreateMatrix(3, 3);
        switch (type)
        {
            case PipeTypes.AnglePipe:
                matrix = UpdateAnglePipe(angle);
                break;
            case PipeTypes.StraightPipe:
                matrix = UpdateStraightPipe(angle);
                break;
            case PipeTypes.TriplePipe:
                matrix = UpdateTriplePipe(angle);
                break;
            case PipeTypes.CrossPipe:
                matrix = UpdateCrossPipe(angle);
                break;
            case PipeTypes.WallPipe:
                matrix = UpdateWallPipe(angle);
                break;
            case PipeTypes.ClosePipe:
                matrix = UpdateClosePipe(angle);
                break;
        }
        return matrix;
    }

    private static int[][] UpdateAnglePipe(int angle)
    {
        int[][] matrix =
        {
            new int[] {1, 1, 1},
            new int[] {1, 0, 0},
            new int[] {1, 0, 1},
        };

        if (angle == 270) 
        {
            matrix[1][2] = 1;
            matrix[1][0] = 0;
        } else if (angle == 180)
        {
            matrix[1][2] = 1;
            matrix[2][1] = 1;
            matrix[1][0] = 0;
            matrix[0][1] = 0;
        } else if (angle == 90)
        {
            matrix[2][1] = 1;
            matrix[0][1] = 0;
        }

        return matrix;
    }

    private static int[][] UpdateStraightPipe(int angle)
    {
        
        if (angle == 0 || angle == 180)
        {
            int[][] matrix =
            {
                new int[] {1, 0, 1},
                new int[] {1, 0, 1},
                new int[] {1, 0, 1},
            };
            return matrix;
        } else
        {
            int[][] matrix =
            {
                new int[] {1, 1, 1},
                new int[] {0, 0, 0},
                new int[] {1, 1, 1},
            };
            return matrix;
        }
    }

    private static int[][] UpdateTriplePipe(int angle)
    {
        int[][] matrix =
        {
            new int[] {1, 0, 1},
            new int[] {1, 0, 0},
            new int[] {1, 0, 1},
        };

        if (angle == 270)
        {
            matrix[0][1] = 1;
            matrix[1][0] = 0;
        }
        else if (angle == 180)
        {
            matrix[1][2] = 1;
            matrix[1][0] = 0;
        }
        else if (angle == 90)
        {
            matrix[2][1] = 1;
            matrix[1][0] = 0;
        }

        return matrix;
    }

    private static int[][] UpdateCrossPipe(int angle)
    {
        int[][] matrix =
        {
            new int[] { 1, 0, 1 },
            new int[] { 0, 0, 0 },
            new int[] { 1, 0, 1 }
        };

        return matrix;
    }

    private static int[][] UpdateWallPipe(int angle)
    {
        int[][] matrix =
        {
            new int[] { 0, 0, 0 },
            new int[] { 0, 0, 0 },
            new int[] { 1, 1, 1 }
        };

        if (angle == 270)
        {
            matrix[2][1] = 0;
            matrix[2][2] = 0;
            matrix[0][0] = 1;
            matrix[1][0] = 1;
        } else if (angle == 180)
        {
            matrix[0] = new int[3] { 1, 1, 1 };
            matrix[2] = new int[3] { 0, 0, 0 };
        } else if (angle == 90)
        {
            matrix[2][0] = 0;
            matrix[2][1] = 0;
            matrix[0][2] = 1;
            matrix[1][2] = 1;
        }
        return matrix;
    }

    private static int[][] UpdateClosePipe(int angle)
    {
        int[][] matrix =
        {
            new int[] { 1, 1, 1 },
            new int[] { 1, 0, 1 },
            new int[] { 1, 0, 1 }
        };

        if (angle == 270)
        {
            matrix[1][0] = 0;
            matrix[2][1] = 1;
        } else if (angle == 180)
        {
            matrix[0][1] = 0;
            matrix[2][1] = 1;
        } else if (angle == 90)
        {
            matrix[1][2] = 0;
            matrix[2][1] = 1;
        }

        return matrix;
    }

    private static int[][] CreateMatrix(int rows, int cols)
    {
        int[][] matrix = new int[rows][];
        for (int i = 0; i != 3; ++i)
            matrix[i] = new int[cols];
        return matrix;
    }
}
 