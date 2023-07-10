using CommunityToolkit.Mvvm.ComponentModel;
using SquaresGame.Extensions;
using SquaresGame.Models;
using System.Windows.Media;

namespace SquaresGame.ViewModels;

public class PlayerViewModel : ObservableObject, IPlayerViewModel
{
    private int _score;

    public PlayerViewModel(Player player)
    {
        Model = player;
        Color = Marker.Color.ToMediaColor();
    }

    public Player Model { get; }
    public Marker Marker => Model.Marker;
    public string Name => Model.Name;
    public Color Color { get; }
    public int Score 
    { 
        get => _score; 
        set => SetProperty(ref _score, value); 
    }
}
