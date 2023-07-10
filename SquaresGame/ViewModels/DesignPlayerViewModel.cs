using System.Windows.Media;

namespace SquaresGame.ViewModels;

public class DesignPlayerViewModel : IPlayerViewModel
{
    public string Name { get; } = "Player 1";
    public int Score { get; } = 100;
    public Color Color { get; } = Colors.IndianRed;
}
