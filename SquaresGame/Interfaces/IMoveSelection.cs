namespace SquaresGame.Interfaces;

public interface IMoveSelection : IMove
{
    new int X { get; set; }
    new int Y { get; set; }

    int Width { get; }
    int Height { get; }

    void Rotate();
}