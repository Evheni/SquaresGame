using SquaresGame.Interfaces;
using SquaresGame.Models;
using System;

namespace SquaresGame.Services;

internal class ScoreKeeperFactory : IScoreKeeperFactory
{
    public IScoreKeeper<TMove> CreateScoreKepper<TMove>(Player player) where TMove : IMove
    {
        var type = typeof(TMove);
        if (type == typeof(Move))
        {
            return (IScoreKeeper<TMove>)new ScoreKeeper(player);
        }

        throw new NotSupportedException();
    }
}
