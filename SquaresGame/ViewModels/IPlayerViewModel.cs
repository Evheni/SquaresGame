using System.Windows.Media;

namespace SquaresGame.ViewModels;

public interface IPlayerViewModel
{
    string Name { get; }
    int Score { get; }
    Color Color { get; }
}