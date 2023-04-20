using Domain.Helpers;
using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Tests.Domain.Tests;

public class ShipHelperTests
{
    [Fact]
    public void CreateShipTests()
    {
        var createdShip = ShipHelper.CreateShip(ShipCoordinate.Create(1, 1).Value, ShipType.Battleship, ShipDirection.Down);
        createdShip.IsSuccess.Should().BeTrue();
    }
    
    [Fact]
    public void CreateShipTests2()
    {
        var createdShip = ShipHelper.CreateShip(ShipCoordinate.Create(1, 10).Value, ShipType.Battleship, ShipDirection.Down);
        createdShip.IsFailed.Should().BeTrue();
    }
    
    [Fact]
    public void CreateShipTests3()
    {
        var createdShip = ShipHelper.CreateShip(ShipCoordinate.Create(10, 1).Value, ShipType.Battleship, ShipDirection.Left);
        createdShip.IsSuccess.Should().BeTrue();
    }
    
    [Fact]
    public void CreateShipTests4()
    {
        var createdShip = ShipHelper.CreateShip(ShipCoordinate.Create(2, 1).Value, ShipType.Battleship, ShipDirection.Left);
        createdShip.IsFailed.Should().BeTrue();
    }
}