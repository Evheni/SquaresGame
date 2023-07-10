using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SquaresGame.Interfaces;
using SquaresGame.Models;
using System;
using System.Windows.Input;

namespace SquaresGame.ViewModels;

public class ClassicGameViewModel : ObservableObject
{
    private readonly Game<RectangularBoard, Move> _model;
    private readonly IMoveFactory<Move> _moveFactory;
    
    private bool _currentPlayerFlag;

    public ClassicGameViewModel(Game<RectangularBoard, Move> model, IMoveFactory<Move> moveFactory)
    {
        MakeMoveCommand = new RelayCommand(MakeMove);
        _model = model;
        _moveFactory = moveFactory;
    }

    public PlayerViewModel Player1 { get; init; }
    public PlayerViewModel Player2 { get; init; }

    public PlayerViewModel CurrentPlayer 
    { 
        get => _currentPlayerFlag ? Player1 : Player2;
    }

    public RectangularBoardViewModel Board { get; init; }
    
    public ICommand MakeMoveCommand { get; }

    public void StartGame()
    {
        UpdateSelection();
        Board.MoveRequested += OnMoveRequested;
    }

    private void OnMoveRequested(object? sender, EventArgs e)
    {
        MakeMove();
    }

    private void MakeMove()
    {
        var finalMove = _moveFactory.FinalizeMove();

        if (_model.MakeMove(CurrentPlayer.Model, finalMove))
        {
            UpdateSelection();
            _currentPlayerFlag = !_currentPlayerFlag;
            Board.CurrentMarker = CurrentPlayer.Marker;
            OnPropertyChanged(nameof(CurrentPlayer));
            UpdateScores();
        }
    }

    private void UpdateScores()
    {
        Player1.Score = _model.GetScore(Player1.Model);
        Player2.Score = _model.GetScore(Player2.Model);
    }

    private void UpdateSelection()
    {
        Board.Selection = _moveFactory.CreateMove();
        Board.CurrentMarker = CurrentPlayer.Marker;
    }
}
