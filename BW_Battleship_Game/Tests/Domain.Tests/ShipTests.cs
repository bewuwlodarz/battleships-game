using Domain.Models;
using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Tests.Domain.Tests;

public class ShipTests
{
    [Fact]
    public void HitExistingCoordinatesOfShip()
    {
        var ship = Ship.Create(ShipType.Battleship,
            new[]
            {
                ShipCoordinate.Create(1, 1).Value, ShipCoordinate.Create(1, 2).Value,ShipCoordinate.Create(1, 3).Value, ShipCoordinate.Create(1, 4).Value,ShipCoordinate.Create(1, 5).Value
            });
        ship.IsSuccess.Should().BeTrue();
        var result = ship.Value.HitShip(ShipCoordinate.Create(1, 1).Value);
        result.Should().BeTrue();
    }
}