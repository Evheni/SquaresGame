using SquaresGame.Interfaces;
using SquaresGame.Models;

namespace SquaresGame.Services;

public class ScoreKeeper : IScoreKeeper<Move>
{
    public ScoreKeeper(Player player)
    {
        Player = player;
    }

    public int Score { get; private set; }
    public Player Player { get; }

    public void AddMoveScore(Move move)
    {
        Score += move.Width * move.Height;
    }
}
