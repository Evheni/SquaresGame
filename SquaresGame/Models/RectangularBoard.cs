using SquaresGame.Interfaces;
using System;
using System.Drawing;

namespace SquaresGame.Models;

internal class RectangularBoard : IBoard<Move>
{
    private readonly Marker[,] _field;
    public RectangularBoard(int width, int height)
    {
        if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));
        if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width));

        Width = width;
        Height = height;

        _field = new Marker[Width, Height];
        CleanTheField();
    }

    public int Width { get; }
    public int Height { get; }

    public Marker this[int x, int y]
    {
        get
        {
            if (x < 0 || x >= Width) throw new ArgumentOutOfRangeException(nameof(x));
            if (y < 0 || y >= Height) throw new ArgumentOutOfRangeException(nameof(y));

            return _field[x, y];
        }
    }

    public Marker this[in Point point]
    {
        get => this[point.X, point.Y];
    }

    public void ApplyMove(Move move, in Marker marker)
    {
        if (move.Position.X < 0 || move.Position.X >= Width
            || move.Position.Y < 0 || move.Position.Y >= Height
            || move.Height < 0 || move.Position.Y + move.Height >= Height
            || move.Width < 0 || move.Position.X + move.Width >= Width) throw new ArgumentOutOfRangeException(nameof(move));

        for (var i = 0; i < move.Width; i++)
        {
            for (var j = 0; j < move.Height; j++)
            {
                _field[move.Position.X + i, move.Position.Y + j] = marker;
            }
        }
    }

    public bool IsMarked(in Point point, in Marker marker)
        => IsMarked(point.X, point.Y, marker);

    public bool IsEmpty(in Point point)
        => IsEmpty(point.X, point.Y);

    public bool IsMarked(int x, int y, in Marker marker)
        => _field[x, y] == marker;

    public bool IsEmpty(int x, int y)
        => _field[x, y] == Marker.Empty;

    private void CleanTheField()
    {
        for (var x =  0; x < Width; x++)
        {
            for (var y = 0; y < Height; y++)
            {
                _field[x, y] = Marker.Empty;
            }
        }
    }
}
