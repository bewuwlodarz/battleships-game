using Domain.Helpers;
using FluentResults;

namespace Domain.ValueObjects;

public record ShipCoordinate : ICoordinate
{
    public bool IsHit { get; private set; }

    private ShipCoordinate(int x, int y, bool isHit = false) 
    {
        X = x;
        Y = y;
        IsHit = isHit;
    }

    public void Hit() => IsHit = true;
    

    private const int minValue = 1;
    private const int maxValue = 10;
    public int X { get; init; }
    public int Y { get; init; }


    public static Result<ShipCoordinate> Create(int x, int y)
    {
        if (x.IsBetween(minValue, maxValue) && y.IsBetween(minValue, maxValue))
            return Result.Ok(new ShipCoordinate(x, y));
        return Result.Fail(new Error("Out of scope coordinates"));
    }


}