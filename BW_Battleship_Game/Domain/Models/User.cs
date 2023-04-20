using Domain.ValueObjects;
using FluentResults;

namespace Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public UserType Type { get; set; }
    public Board Board { get; set; }


    public static Result<User> Create(ShipType type, ShipCoordinate[] coordinates)
    {
        return Result.Ok();
    }
}