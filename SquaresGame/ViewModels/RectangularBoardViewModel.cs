using CommunityToolkit.Mvvm.ComponentModel;
using SquaresGame.Interfaces;
using SquaresGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace SquaresGame.ViewModels;
public class RectangularBoardViewModel : ObservableObject
{
    private readonly RectangularBoard _model;
    private IMoveSelection _selection;
    private ObservableCollection<ObservableCollection<ICellViewModel>> _cells;

    public RectangularBoardViewModel(RectangularBoard rectangularBoard)
    {
        _model = rectangularBoard;

        UpdateCells();
        // TODO: Add dispose
        _model.MarkerUpdated += CellMarkerUpdated;
    }

    public IMoveSelection Selection
    {
        get => _selection;
        set => SetProperty(ref _selection, value);
    }

    public Marker CurrentMarker { get; set; }

    public ObservableCollection<ObservableCollection<ICellViewModel>> Cells
    {
        get { return _cells; }
        set { SetProperty(ref _cells, value); }
    }

    public void ApplyMove(in Move move, PlayerViewModel player)
    {
        _model.ApplyMove(move, player.Marker);
    }

    private void CellMarkerUpdated(object? _, (int X, int Y) e)
    {
        Cells.ElementAt(e.Y).ElementAt(e.X).UpdateMarker(_model[e.X, e.Y]);
    }

    private void UpdateCells()
    {
        var cells = new ObservableCollection<ObservableCollection<ICellViewModel>>();
        for (var posRow = 0; posRow < _model.Height; posRow++)
        {
            var row = new ObservableCollection<ICellViewModel>();
            for (var posCol = 0; posCol < _model.Width; posCol++)
            {
                var point = new Point(posCol, posRow);
                var cellViewModel = new CellViewModel(_model[point], point);
                cellViewModel.CellSelected += OnCellSelected;
                cellViewModel.RotationRequested += OnRotationRequested;
                cellViewModel.MoveRequested += OnMoveRequested;
                row.Add(cellViewModel);
            }

            cells.Add(row);
        }

        Cells = cells;
    }

    public event EventHandler MoveRequested;
    private void OnMoveRequested(object? sender, EventArgs e)
    {
        MoveRequested?.Invoke(sender, e);
    }

    private void OnRotationRequested(object? sender, EventArgs e)
    {
        RotateSelection();
        if (sender is CellViewModel cell)
        {
            var position = cell.Position;
            UpdateSelection(position);
        }
    }

    private void RotateSelection()
    {
        Selection.Rotate();
    }

    private void OnCellSelected(object? sender, EventArgs e)
    {
        if (sender is CellViewModel cell)
        {
            var position = cell.Position;
            UpdateSelection(position);
        }
    }

    private IList<ICellViewModel> _selectedCells = new List<ICellViewModel>();
    private void UpdateSelection(Point position)
    {
        foreach (var cell in _selectedCells)
        {
            cell.ResetMark();
        }

        _selectedCells.Clear();

        var midW = Selection.Width / 2;
        var midH = Selection.Height / 2;
        var leftIndex = Math.Max(0, position.X - midW);
        var topIndex = Math.Max(0, position.Y - midH);
        if (Selection.Width + leftIndex >= _model.Width)
        {

        }

        _selection.X = leftIndex;
        _selection.Y = topIndex;
        var rightIndex = Math.Min(Selection.Width + leftIndex, _model.Width);
        var bottomIndex = Math.Min(Selection.Height + topIndex, _model.Height);
        for (var i = topIndex; i < bottomIndex; i++)
        {
            for (var j = leftIndex; j < rightIndex; j++)
            {
                var cell = Cells[i][j];
                _selectedCells.Add(cell);
                cell.Mark(CurrentMarker.Color);
            }
        }
    }
}
