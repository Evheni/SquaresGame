namespace SquaresGame.Interfaces;

internal interface IScoreKeeper<TMove> where TMove : IMove
{
    int Score { get; }
    void AddMoveScore(TMove move);
}
