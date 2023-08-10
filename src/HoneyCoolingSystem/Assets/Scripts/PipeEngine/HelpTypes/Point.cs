
public struct Point
{
    public int row, col;

    public Point(int r, int c)
    {
        row = r;
        col = c;
    }
};

public struct SidePoint
{
    public int x, y, value;

    public SidePoint(int x1, int y1, int value1)
    {
        x = x1;
        y = y1;
        value = value1;
    }
}