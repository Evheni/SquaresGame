namespace SquaresGame.Interfaces;

public interface IScoreKeeper<TMove> where TMove : IMove
{
    int Score { get; }
    void AddMoveScore(TMove move);
}
