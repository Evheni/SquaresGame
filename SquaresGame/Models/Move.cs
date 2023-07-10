using SquaresGame.Interfaces;
using System.Drawing;

namespace SquaresGame.Models;

internal readonly record struct Move(Point Position, int Width, int Height) : IMove
{
    public int X => Position.X;
    public int Y => Position.Y;
}