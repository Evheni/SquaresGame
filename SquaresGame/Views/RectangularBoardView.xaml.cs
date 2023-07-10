using System.Windows;
using System.Windows.Controls;

namespace SquaresGame.Views;
/// <summary>
/// Interaction logic for RectangularBoardView.xaml
/// </summary>
public partial class RectangularBoardView : UserControl
{
    public static readonly DependencyProperty BoardWidthProperty = DependencyProperty.RegisterAttached(nameof(BoardWidth), 
        typeof(int), typeof(RectangularBoardView), new PropertyMetadata(100));

    public static readonly DependencyProperty BoardHeightProperty = DependencyProperty.RegisterAttached(nameof(BoardHeight),
        typeof(int), typeof(RectangularBoardView), new PropertyMetadata(100));

    public RectangularBoardView()
    {
        InitializeComponent();
    }

    public int BoardWidth
    {
        get { return (int)GetValue(BoardWidthProperty); }
        set { SetValue(BoardWidthProperty, value); }
    }

    public int BoardHeight
    {
        get { return (int)GetValue(BoardHeightProperty); }
        set { SetValue(BoardHeightProperty, value); }
    }
}
