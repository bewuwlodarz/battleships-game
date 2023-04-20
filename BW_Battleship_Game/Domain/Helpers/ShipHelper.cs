using Domain.ValueObjects;
using FluentResults;

namespace Domain.Helpers;

public static class ShipHelper
{
    public static Result<ShipCoordinate[]> CreateShip(ShipCoordinate shipCoordinate, ShipType type, ShipDirection direction)
    {
        
        switch (direction)
        {
            case ShipDirection.Up:
                return Generate(shipCoordinate, type, false, false);
            case ShipDirection.Down:
                return Generate(shipCoordinate, type, false, true);
            case ShipDirection.Left:
                return Generate(shipCoordinate, type, true, false);
            case ShipDirection.Right:
                return Generate(shipCoordinate, type, true, true);
        }

        return Result.Fail("main error");
    }

    public static Result<ShipCoordinate[]> Generate(ShipCoordinate shipCoordinate, ShipType type, bool isVertically, bool isIncrement)
    {
        var coordinates = new ShipCoordinate[type.Slots];
        coordinates[0] = shipCoordinate;
        for (int i = 1; i < type.Slots; i++)
        {
            var currentX = isVertically ? (isIncrement ? shipCoordinate.X + i : shipCoordinate.X - i) : shipCoordinate.X;
            var currentY = !isVertically ? (isIncrement ? shipCoordinate.Y + i : shipCoordinate.Y - i) : shipCoordinate.Y;
            var currentShipCoordinate = ShipCoordinate.Create(currentX, currentY);
            if (currentShipCoordinate.IsSuccess)
            {
                coordinates[i] = currentShipCoordinate.Value;
            }
            else
            {
                return Result.Fail("error");
            }
        }

        return Result.Ok(coordinates);
    }

}