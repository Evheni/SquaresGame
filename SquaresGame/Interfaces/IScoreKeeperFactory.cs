using SquaresGame.Models;

namespace SquaresGame.Interfaces;

internal interface IScoreKeeperFactory
{
    IScoreKeeper<TMove> CreateScoreKepper<TMove>(Player player) where TMove : IMove;
}