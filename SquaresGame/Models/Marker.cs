using System;
using System.Drawing;

namespace SquaresGame.Models;

public readonly record struct Marker(Color Color) 
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public static readonly Marker Empty = new(Color.Transparent) { Id = Guid.Empty };
}
