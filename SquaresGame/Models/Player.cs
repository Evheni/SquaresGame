using System;

namespace SquaresGame.Models;

public record Player(string Name, Marker Marker)
{
    public Guid Id { get; } = Guid.NewGuid();
}