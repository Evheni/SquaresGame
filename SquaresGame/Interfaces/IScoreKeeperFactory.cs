using SquaresGame.Models;

namespace SquaresGame.Interfaces;

public interface IScoreKeeperFactory
{
    IScoreKeeper<TMove> CreateScoreKepper<TMove>(Player player) where TMove : IMove;
}