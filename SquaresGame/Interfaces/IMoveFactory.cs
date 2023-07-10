namespace SquaresGame.Interfaces;

public interface IMoveFactory<TMove> where TMove : IMove
{
    IMoveSelection CreateMove();
    TMove FinalizeMove();
}
