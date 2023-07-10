using SquaresGame.Interfaces;
using SquaresGame.Models;
using SquaresGame.Services;
using SquaresGame.ViewModels;
using System.Windows;

namespace SquaresGame;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var player1 = new Player("Player 1", new Marker(System.Drawing.Color.OrangeRed));
        var player2 = new Player("Player 2", new Marker(System.Drawing.Color.CornflowerBlue));
        var board = new RectangularBoard(100, 50);
        board.InitStart(0, 0, player1.Marker);
        board.InitStart(board.Width - 1, board.Height - 1, player2.Marker);

        var scoreKeeperFactory = new ScoreKeeperFactory();
        var moveValidator = new MoveValidator();
        var game = new Game<RectangularBoard, Move>(board, scoreKeeperFactory, moveValidator);
        game.AddPlayer(player1);
        game.AddPlayer(player2);

        var moveFactory = new MoveFactory();
        var gameVM = new ClassicGameViewModel(game, moveFactory)
        {
            Player1 = new PlayerViewModel(player1),
            Player2 = new PlayerViewModel(player2),
            Board = new RectangularBoardViewModel(board)
        };

        DataContext = gameVM;
        gameVM.StartGame();
    }
}
