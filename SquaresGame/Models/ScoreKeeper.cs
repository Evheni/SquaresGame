using SquaresGame.Interfaces;

namespace SquaresGame.Models;

internal class ScoreKeeper : IScoreKeeper<Move>
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
