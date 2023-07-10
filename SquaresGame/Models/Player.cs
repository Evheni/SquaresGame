using System;

namespace SquaresGame.Models;

internal record Player(string Name, Marker Marker)
{
    public Guid Id { get; } = Guid.NewGuid();
}