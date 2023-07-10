using SquaresGame.Models;

namespace SquaresGame.Interfaces;
public interface IMoveValidator<TBoard, TMove> 
    where TMove : IMove
    where TBoard : IBoard<TMove>
{
    bool IsMoveValid(TBoard board, TMove move, in Marker marker);
}
