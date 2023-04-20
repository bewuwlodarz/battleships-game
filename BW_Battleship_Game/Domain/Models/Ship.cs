using Domain.ValueObjects;
using FluentResults;

namespace Domain.Models;

public class Ship
{
    public ShipType Type { get; set; }
    public ShipCoordinate[] Coordinates { get; set; }

    private Ship(ShipType type, ShipCoordinate[] coordinates)
    {
        Type = type;
        Coordinates = coordinates;
        
    }

    public bool IsShipSunk() => Coordinates.All(x => x.IsHit);

    public bool HitShip(ICoordinate coordinate)
    {
        if (!Coordinates.Contains(coordinate)) return false;
        var hitCoordinate = Coordinates[Array.IndexOf(Coordinates, coordinate)];
        hitCoordinate.Hit();
        return true;

    }

    public static Result<Ship> Create(ShipType type, ShipCoordinate[] coordinates)
    {
        if (coordinates.Length == type.Slots)
            return Result.Ok(new Ship(type, coordinates));
        return Result.Fail(new Error("Not proper coordinates per slot of ship"));
    }
}