using SquaresGame.Models;
using System.Drawing;

namespace SquaresGame.ViewModels;

public interface ICellViewModel
{
    void UpdateMarker(Marker marker);
    void ResetMark();
    void Mark(Color color);
}
