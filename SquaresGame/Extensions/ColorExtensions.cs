﻿namespace SquaresGame.Extensions;

public static class ColorExtensions
{
    public static System.Windows.Media.Color ToMediaColor(this System.Drawing.Color color)
        => System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
}