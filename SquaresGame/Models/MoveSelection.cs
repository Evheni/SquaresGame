using SquaresGame.Interfaces;

namespace SquaresGame.ViewModels;

public class MoveSelection : IMoveSelection
{
    public MoveSelection(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Width { get; private set; } 
    public int Height { get; private set; }

    public int X { get; set; }
    public int Y { get; set; }

    public void Rotate()
    {
        (Height, Width) = (Width, Height);
    }
}
