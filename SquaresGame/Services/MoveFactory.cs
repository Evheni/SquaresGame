using SquaresGame.Interfaces;
using SquaresGame.Models;
using System;
using System.Drawing;

namespace SquaresGame.Services;

public class MoveFactory : IMoveFactory<Move>
{
    private readonly int _w;
    private readonly int _h;
    private MoveSelection? _selection;

    public MoveFactory(int w = 6, int h = 6)
    {
        _w = w;
        _h = h;
    }

    public IMoveSelection CreateMove()
    {
        var x = Random.Shared.Next(1, _w);
        var y = Random.Shared.Next(1, _h);

        _selection = new MoveSelection(x, y);

        return _selection;
    }

    public Move FinalizeMove()
    {
        if (_selection is null) throw new InvalidOperationException();

        var point = new Point(_selection.X, _selection.Y);
        return new Move(point, _selection.Width, _selection.Height);
    }
}
