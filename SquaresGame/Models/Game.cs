using SquaresGame.Interfaces;
using System.Collections.Generic;

namespace SquaresGame.Models;
public class Game<TBoard, TMove> 
    where TBoard : IBoard<TMove>
    where TMove : IMove
{
    private readonly IMoveValidator<TBoard, TMove> _moveValidator;
    private readonly IScoreKeeperFactory _scoreKeeperFactory;
    private readonly IDictionary<Player, IScoreKeeper<TMove>> _scoreKeepers 
        = new Dictionary<Player, IScoreKeeper<TMove>>();

    public Game(TBoard board,
        IScoreKeeperFactory scoreKeeperFactory,
        IMoveValidator<TBoard, TMove> moveValidator)
    {
        Board = board;
        _scoreKeeperFactory = scoreKeeperFactory;
        _moveValidator = moveValidator;
    }

    public TBoard Board { get; }

    public int GetScore(Player player)
    {
        if (_scoreKeepers.TryGetValue(player, out var scoreKeeper)) 
        {
            return scoreKeeper.Score;
        }

        return 0;
    }

    public void AddPlayer(Player player)
    {
        var scoreKeeper = _scoreKeeperFactory.CreateScoreKepper<TMove>(player);
        _scoreKeepers.Add(player, scoreKeeper);
    }

    public bool MakeMove(Player player, TMove move)
    {
        if (!_moveValidator.IsMoveValid(Board, move, player.Marker)) return false;

        Board.ApplyMove(move, player.Marker);
        var scoreKeeper = _scoreKeepers[player];
        scoreKeeper.AddMoveScore(move);

        return true;
    }
}
