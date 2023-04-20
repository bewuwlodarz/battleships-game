using Domain.Helpers;
using FluentResults;

namespace Domain.ValueObjects;

public record Coordinate : ICoordinate
{
    protected Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    private const int minValue = 1;
    private const int maxValue = 10;
    public int X { get; init; }
    public int Y { get; init; }


    public static Result<Coordinate> Create(int x, int y)
    {
        if (x.IsBetween(minValue,maxValue) || y.IsBetween(minValue, maxValue))
            return Result.Ok(new Coordinate(x,y));
        return Result.Fail(new Error("Out of scope coordinates"));
    }
    
}