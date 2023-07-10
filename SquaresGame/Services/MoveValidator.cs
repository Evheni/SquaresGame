using SquaresGame.Interfaces;
using SquaresGame.Models;

namespace SquaresGame.Services;

internal class MoveValidator : IMoveValidator<RectangularBoard, Move>
{
    public bool IsMoveValid(RectangularBoard board, Move move, in Marker marker)
        => IsPositionValid(board, move)
        && IsSizeValid(board, move)
        && IsAttached(board, move, marker)
        && IsEmpty(board, move);

    private static bool IsPositionValid(RectangularBoard board, in Move move)
        => move.X < 0 || move.X >= board.Width
        || move.Y < 0 || move.Y >= board.Height;

    private static bool IsSizeValid(RectangularBoard board, in Move move)
        => move.Height < 0 || move.Position.Y + move.Height >= board.Height
        || move.Width < 0 || move.Position.X + move.Width >= board.Width;

    private static bool IsAttached(RectangularBoard board, in Move move, in Marker marker)
    {
        if (move.X > 0)
        {
            var x = move.X - 1;
            for (var i = 0; i < move.Height; i++)
            {
                if (board.IsMarked(x, move.Y + i, marker))
                {
                    return true;
                }
            }
        }

        if (move.Y > 0)
        {
            var y = move.Y - 1;
            for (var i = 0; i < move.Width; i++)
            {
                if (board.IsMarked(y, move.X + i, marker))
                {
                    return true;
                }
            }
        }

        if (move.X + move.Width < board.Width - 1)
        {
            var x = move.X + move.Width + 1;
            for (var i = 0; i < move.Height; i++)
            {
                if (board.IsMarked(x, move.Y + i, marker))
                {
                    return true;
                }
            }
        }

        if (move.Y + move.Height < board.Height - 1)
        {
            var y = move.Y + move.Height + 1;
            for (var i = 0; i < move.Width; i++)
            {
                if (board.IsMarked(y, move.X + i, marker))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool IsEmpty(RectangularBoard board, in Move move)
    {
        for (var i = 0; i < move.Width; i++)
        {
            for (var j = 0; j < move.Height; j++)
            {
                if (board.IsEmpty(move.Position.X + i, move.Position.Y + j))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
