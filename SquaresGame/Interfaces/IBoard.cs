using SquaresGame.Models;
using System.Drawing;

namespace SquaresGame.Interfaces;

internal interface IBoard<TMove> where TMove : IMove
{
    Marker this[int x, int y] { get; }
    Marker this[in Point point] { get; }
    void ApplyMove(TMove move, in Marker marker);
    bool IsMarked(in Point point, in Marker marker);
    bool IsEmpty(in Point point);
    bool IsMarked(int x, int y, in Marker marker);
    bool IsEmpty(int x, int y);
}
