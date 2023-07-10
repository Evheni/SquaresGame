using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SquaresGame.Extensions;
using SquaresGame.Models;
using System;
using System.Windows.Input;
using System.Windows.Media;

namespace SquaresGame.ViewModels;

public class CellViewModel : ObservableObject, ICellViewModel
{
    private Color _currentColor;
    private bool _isSelected;
    private Color _selectedColor;

    public CellViewModel(Marker marker, System.Drawing.Point position)
    {
        CurrentColor = DefaultColor;
        UpdateMarker(marker);
        Position = position;

        SelectedColor = SelectedDefaultColor;
        ClickedCommand = new RelayCommand<bool>(Clicked);
    }

    public event EventHandler CellSelected;
    public event EventHandler MoveRequested;
    public event EventHandler RotationRequested;

    public ICommand ClickedCommand { get; }

    public Color CurrentColor 
    { 
        get => _currentColor; 
        set => SetProperty(ref _currentColor, value); 
    }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (SetProperty(ref _isSelected, value) && value)
            {
                CellSelected?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public System.Drawing.Point Position { get; }

    public Color DefaultColor { get; init; } = Colors.WhiteSmoke;

    public Color SelectedDefaultColor { get; init; } = Colors.Gray;
    public Color SelectedColor 
    { 
        get => _selectedColor; 
        set => SetProperty(ref _selectedColor, value); 
    }

    public void ResetMark()
    {
        SelectedColor = SelectedDefaultColor;
    }

    public void Mark(System.Drawing.Color color)
    {
        SelectedColor = color.ToMediaColor();
    }

    public void UpdateMarker(Marker marker)
    {
        CurrentColor = marker == Marker.Empty 
            ? DefaultColor 
            : marker.Color.ToMediaColor();
    }

    private void Clicked(bool isLeft)
    {
        if (isLeft)
            MoveRequested?.Invoke(this, EventArgs.Empty);
        else
            RotationRequested?.Invoke(this, EventArgs.Empty);
    }
}
